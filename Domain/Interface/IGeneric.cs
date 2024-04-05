using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IGeneric<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<int> Disable(int id);

    }
}
