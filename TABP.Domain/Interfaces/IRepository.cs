using System.Linq.Expressions;
using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TResult?> GetByIdAsync<TResult>(Guid id, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<bool> IsExistAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> IsExistsByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
