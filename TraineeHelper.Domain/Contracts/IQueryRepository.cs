using System.Linq.Expressions;
using TraineeHelper.Domain.Contracts;

namespace TraineeHelper.Persistence.Abstractions;

/// <summary>
/// Query repository contract
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TKey">Entity primary key</typeparam>
public interface IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
}
