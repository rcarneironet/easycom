namespace Easycom.Core.Interfaces.Repository
{
    using Easycom.Core.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAsync(int index, int pagesize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
    }
}
