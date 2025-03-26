using System.Linq.Expressions;

namespace DesafioPicPay.Core.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task SaveAsync(T entity, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(string value, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<T> Search(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}