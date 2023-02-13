using System.Linq.Expressions;
using TraineeHelper.Domain.Contracts;

namespace TraineeHelper.Domain.Contracts;

/// <summary>
/// Command repository contract
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TKey">Entity primary key</typeparam>
public interface ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    TEntity UpdateAsync(TEntity entity);
    TEntity DeleteAsync(TEntity entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
