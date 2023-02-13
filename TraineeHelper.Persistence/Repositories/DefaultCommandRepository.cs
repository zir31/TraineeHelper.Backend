using TraineeHelper.Domain.Contracts;
using TraineeHelper.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace TraineeHelper.Persistence.Repositories;
/// <summary>
/// Default command repository with base actions
/// </summary>
/// <typeparam name="TEntity">Entity</typeparam>
/// <typeparam name="TContext">DbContext</typeparam>
/// <typeparam name="TKey">Primary key</typeparam>
public class DefaultCommandRepository<TEntity, TContext, TKey> : BaseCommandRepository<TEntity, TContext, TKey>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    public DefaultCommandRepository(TContext dbContext) : base(dbContext)
    {
    }
}
