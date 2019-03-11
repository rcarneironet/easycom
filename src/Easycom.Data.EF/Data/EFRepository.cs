using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easycom.Core.Base;
using Easycom.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Easycom.Data.EF.Data
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppContext _dbContext;
        public EFRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<T>()
                .AsNoTracking()
                .Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(int index, int pagesize)
        {
            return await _dbContext.Set<T>()
                .Skip(index)
                .Take(pagesize)
                .ToListAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
