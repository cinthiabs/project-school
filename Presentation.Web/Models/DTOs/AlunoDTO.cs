namespace Presentation.Web.Models.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Usuario { get; set; } 
        public string Senha { get; set; } 
        public bool Ativo { get; set; } = true;
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
