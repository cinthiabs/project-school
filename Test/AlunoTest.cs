using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace Test
{
    public class AlunoTest
    {

        private const string ApiBaseUrl = "https://localhost:44328/api/Aluno";

        [Fact]
        public async Task TestCreateAluno_PostRequest_Password()
        {
            var alunoSenhaFraca = new
            {
                nome = "Create New Aluno",
                usuario = "teste123",
                senha = "123",
                ativo = true,
                data_criacao = DateTime.Now
            };

            // Act
            var responseContent = await ChamaApiPost(ApiBaseUrl, alunoSenhaFraca);

            // Assert
            Assert.NotNull(responseContent);
            Assert.Contains("A senha deve ter pelo menos 8 caracteres, uma letra minúscula, uma letra maiúscula e um caractere especial.", responseContent);
        }


        public async Task<string> ChamaApiPost(string url, object dados = null)
        {
            string json = dados != null ? JsonConvert.SerializeObject(dados) : "";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var response = await client.PostAsync(url, content);
                return   await response.Content.ReadAsStringAsync();
            
            }
        }
    }
}