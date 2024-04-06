using Presentation.Web.Models.DTOs;
using System.Text.Json;
using System.Text;

namespace Presentation.Web.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly HttpClient _httpClient;
        public TurmaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Create(TurmaDTO turma)
        {
            var json = JsonSerializer.Serialize(turma);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Turma", content);
            return response;
        }

        public async Task Delete(int turmaId)
        {
            var response = await _httpClient.DeleteAsync($"api/Turma/{turmaId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task Disable(int turmaId)
        {

            var response = await _httpClient.PutAsync($"api/Turma/Disable/{turmaId}",null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<TurmaDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Turma");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var turma = JsonSerializer.Deserialize<List<TurmaDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return turma;
        }
        public async Task<TurmaDTO> GetById(int turmaId)
        {
            var response = await _httpClient.GetAsync($"api/Turma/{turmaId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var turma = JsonSerializer.Deserialize<TurmaDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return turma;
        }
        public async Task<HttpResponseMessage> Update(int turmaId, TurmaDTO turma)
        {
            var json = JsonSerializer.Serialize(turma);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Turma/{turmaId}", content);
            return response;
        }
    }
}
