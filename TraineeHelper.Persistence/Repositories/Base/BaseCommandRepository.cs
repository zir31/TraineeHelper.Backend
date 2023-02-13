using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Domain.Contracts;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Persistence.Repositories.Base;

/// <summary>
/// Base implementation for read and write repo
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TContext">DbContext</typeparam>
/// <typeparam name="TKey">Primary key</typeparam>
public abstract class BaseCommandRepository<TEntity, TContext, TKey> : BaseQueryRepository<TEntity, TContext, TKey>, ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    protected BaseCommandRepository(TContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<TEntity> Query => DbSet;

    public override async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await Query.FirstOrDefaultAsync(predicate, cancellationToken);

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = await DbSet.AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public virtual TEntity UpdateAsync(TEntity entity)
    {
        var entry = DbSet.Update(entity);
        return entry.Entity;
    }

    public virtual TEntity DeleteAsync(TEntity entity)
    {
        var entry = DbSet.Remove(entity);
        return entry.Entity;
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
