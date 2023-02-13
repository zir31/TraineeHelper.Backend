using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Domain.Contracts;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Persistence.Repositories.Base;

/// <summary>
/// Base implrementation repository for QueryHandlers with read actions
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TContext">Db Context</typeparam>
/// <typeparam name="TKey">PK of entity</typeparam>
public abstract class BaseQueryRepository<TEntity, TContext, TKey> : IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{

    protected readonly TContext DbContext;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseQueryRepository(TContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    /// <summary>
    /// For read actions use as no tacking
    /// </summary>
    protected virtual IQueryable<TEntity> Query => DbSet.AsNoTracking();

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await Query
            .FirstOrDefaultAsync(predicate, cancellationToken);

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await Query
            .Where(predicate)
            .ToListAsync(cancellationToken);

    public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => Query
            .FirstOrDefault(predicate);
}
