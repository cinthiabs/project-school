using Presentation.Web.Models.DTOs;

namespace Presentation.Web.Services
{
    public interface IAluno_TurmaService
    {
        Task<IEnumerable<Aluno_TurmaDTO>> GetAll();
        Task<Aluno_TurmaDTO> GetById(int entityID);
        Task<HttpResponseMessage> Create(Aluno_TurmaDTO entity);
        Task Update(int entityID, Aluno_TurmaDTO entity);
        Task Delete(int entityID);
        Task Disable(int entityID);
    }
}
