namespace Presentation.Web.Models.DTOs
{
    public class Aluno_TurmaDTO
    {
        public int Id { get; set; }

        public int Aluno_Id { get; set; }

        public int Turma_Id { get; set; }

        public bool Ativo { get; set; } = true;
        public DateTime Data_Criacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
