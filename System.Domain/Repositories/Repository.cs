using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Domain.Interfaces;

namespace System.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public Repository(ApplicationDbContext context)
            => _context = context;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetByIDAsync(Guid? id)
            => await _context.Set<TEntity>().FindAsync(id);

        public void Create(TEntity entity)
            => _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            //_context.Set<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}