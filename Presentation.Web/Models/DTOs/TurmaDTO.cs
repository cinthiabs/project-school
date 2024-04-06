
using Presentation.Web.Models.Enums;
using System.Text.Json.Serialization;

namespace Presentation.Web.Models.DTOs
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public int Curso_Id { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
        
        [JsonIgnore]
        public string CursoName => Enum.GetName(typeof(Curso), Curso_Id);
    }
}
