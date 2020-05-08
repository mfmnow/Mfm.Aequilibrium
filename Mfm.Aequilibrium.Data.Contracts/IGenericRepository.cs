using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> GetByIds(List<int> ids);
        Task Update(T entity);
        Task Delete(int id);
    }
}
