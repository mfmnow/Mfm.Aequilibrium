using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mfm.Aequilibrium.Data.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TestDbContext _context;

        public GenericRepository(TestDbContext testDbContext)
        {
            _context = testDbContext;
        }

        public virtual async Task Create(T entity)
        {
            _context.Set<T>();
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<List<T>> GetByIds(List<int> ids)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(e =>  ids.Contains(e.Id))
                .ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>();
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            _context.Set<T>();
            var entity = await GetById(id);
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
