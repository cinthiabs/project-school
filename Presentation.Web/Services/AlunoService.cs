using Presentation.Web.Models.DTOs;
using System.Text;
using System.Text.Json;

namespace Presentation.Web.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly HttpClient _httpClient;
        public AlunoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(AlunoDTO aluno)
        {
            var json = JsonSerializer.Serialize(aluno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Aluno", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<AlunoDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Aluno");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var alunos = JsonSerializer.Deserialize<List<AlunoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return alunos;
        }
        public async Task Update(int alunoId, AlunoDTO aluno)
        {
            var json = JsonSerializer.Serialize(aluno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Aluno/{alunoId}", content);

            response.EnsureSuccessStatusCode();
        }
        public async Task Delete(int alunoId)
        {
            var response = await _httpClient.DeleteAsync($"api/Aluno/{alunoId}");

            response.EnsureSuccessStatusCode();
        }

        public async Task Disable(int alunoId)
        {
            var response = await _httpClient.PutAsync($"api/Aluno/Disable/{alunoId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<AlunoDTO> GetById(int alunoId)
        {
            var response = await _httpClient.GetAsync($"api/Aluno/{alunoId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var alunos = JsonSerializer.Deserialize<AlunoDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return alunos;
        }
    }
}
