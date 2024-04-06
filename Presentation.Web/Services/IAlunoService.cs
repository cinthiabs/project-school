using Presentation.Web.Models.DTOs;

namespace Presentation.Web.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAll();
        Task<AlunoDTO> GetById(int alunoId);
        Task<HttpResponseMessage> Create(AlunoDTO aluno);
        Task<HttpResponseMessage> Update(int alunoId, AlunoDTO aluno);
        Task Delete(int alunoId);
        Task Disable(int alunoId);
    }
}
