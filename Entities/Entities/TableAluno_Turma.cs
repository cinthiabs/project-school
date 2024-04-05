using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TableAluno_Turma
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aluno_id")]
        public int Aluno_Id { get; set; }
        
        [JsonProperty("turma_id")]
        public int Turma_Id { get; set; }
        
        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
        [JsonProperty("data_criacao")]
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
