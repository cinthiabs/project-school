using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRole<T>
    {
        Task<T> GetTurmaByName(string nome);
        Task<T> GetAlunoTurmaByAlunoIdAndTurmaId(int alunoId, int turmaId);
    }
}
