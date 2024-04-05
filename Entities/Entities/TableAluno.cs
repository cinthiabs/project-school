using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class TableAluno
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [JsonProperty("usuario")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usuario { get; set; }

        [JsonProperty("senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
        
    }
}
