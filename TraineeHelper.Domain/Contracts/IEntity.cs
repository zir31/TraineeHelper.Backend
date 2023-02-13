namespace TraineeHelper.Domain.Contracts;

/// <summary>
/// Interface exposes base contract for Entity in solution.
/// </summary>
/// <typeparam name="TPrimaryKey">Entity primary key</typeparam>
public interface IEntity<out TPrimaryKey>
{
    /// <summary>
    /// Entity identifier.
    /// </summary>
    TPrimaryKey Id { get; }
}
