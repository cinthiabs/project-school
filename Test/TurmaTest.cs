using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TurmaTest
    {
        private const string ApiBaseUrl = "https://localhost:44328/api/Turma";

        [Fact]
        public async Task TestTurma_PostRequest_ValidaData()
        {
            var Turma = new
            {
                Curso_Id = 2,
                Turma = "ADM_Manha",
                Ano = 2024,
                ativo = true,
                data_criacao = "2024-03-05T07:21:59.155Z"
            };

            // Act
            var responseContent = await ChamaApiPost(ApiBaseUrl, Turma);

            // Assert
            Assert.NotNull(responseContent);
            Assert.Contains("A data de criação da turma não pode ser anterior à data atual.", responseContent);
        }


        public async Task<string> ChamaApiPost(string url, object dados = null)
        {
            string json = dados != null ? JsonConvert.SerializeObject(dados) : "";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                var response = await client.PostAsync(url, content);
                return await response.Content.ReadAsStringAsync();

            }
        }
    }
}
