using Presentation.Web.Models.DTOs;
using System.Text.Json;
using System.Text;

namespace Presentation.Web.Services
{
    public class Aluno_TurmaService : IAluno_TurmaService
    {
        private readonly HttpClient _httpClient;
        public Aluno_TurmaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Create(Aluno_TurmaDTO entity)
        {
            var json = JsonSerializer.Serialize(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Aluno_Turma", content);

            return response;
        }
        public async Task Delete(int entityID)
        {
            var response = await _httpClient.DeleteAsync($"api/Aluno_Turma/{entityID}");
            response.EnsureSuccessStatusCode();
        }

        public async Task Disable(int entityID)
        {
            var response = await _httpClient.PutAsync($"api/Aluno_Turma/Disable/{entityID}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Aluno_TurmaDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Aluno_Turma");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var aluno_turma = JsonSerializer.Deserialize<List<Aluno_TurmaDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return aluno_turma;
        }

        public async Task<Aluno_TurmaDTO> GetById(int entityID)
        {
            var response = await _httpClient.GetAsync($"api/Aluno_Turma/{entityID}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var aluno_turma = JsonSerializer.Deserialize<Aluno_TurmaDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return aluno_turma;
        }

        public async  Task Update(int entityId, Aluno_TurmaDTO entity)
        {
            var json = JsonSerializer.Serialize(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Aluno_Turma/{entityId}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
