using TABP.Domain.Entities;
using TABP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TABP.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly TABPDbContext _context;

        protected Repository(TABPDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity.Id;
        }

        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public Task<TResult?> GetByIdAsync<TResult>(Guid id,
            Expression<Func<T, TResult>> selector,
            CancellationToken cancellationToken = default)
        {
            return _dbSet
                .Where(e => e.Id == id)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<bool> IsExistAsync(T entity, CancellationToken cancellationToken = default)
        {
            return _dbSet.AnyAsync(e => e.Id == entity.Id, cancellationToken);
        }

        public Task<bool> IsExistsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
