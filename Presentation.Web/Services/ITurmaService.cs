using Presentation.Web.Models.DTOs;

namespace Presentation.Web.Services
{
    public interface ITurmaService
    {
        Task<IEnumerable<TurmaDTO>> GetAll();
        Task<TurmaDTO> GetById(int turmaId);
        Task<HttpResponseMessage> Create(TurmaDTO turma);
        Task <HttpResponseMessage> Update(int turmaId, TurmaDTO turma);
        Task Delete(int turmaId);
        Task Disable(int turmaId);

    }
}
