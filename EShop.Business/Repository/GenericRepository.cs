using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Business.Interfaces;
using EShop.DataAccessor.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop.Business.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbContext;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<T>();

        }
        public DbSet<T> DbSet => DbContext.Set<T>();

        public DbContext DbContext { get; set; }
 
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.ToListAsync<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.FindAsync(id);
        }

        public async Task InsertAsync(T obj)
        {
            await _dbContext.AddAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            _dbContext.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task RemoveAsync(object id)
        {
            T existing = await _dbContext.FindAsync(id);
            if (existing != null)
                _dbContext.Remove(existing);
        }
    }
}