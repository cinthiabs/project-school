using Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TableTurma
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        
        [JsonProperty("curso_id")]
        public int Curso_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        
        [JsonProperty("turma")]
        public string Turma { get; set; }

        [JsonProperty("ano")]
        public int Ano { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
