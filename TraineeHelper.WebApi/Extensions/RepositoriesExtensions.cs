using TraineeHelper.Domain.Contracts;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Persistence;
using TraineeHelper.Persistence.Abstractions;
using TraineeHelper.Persistence.Repositories;

namespace TraineeHelper.WebApi.Extensions;

/// <summary>
/// Extension for repositories registration
/// </summary>
public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ICommandRepository<LearningSession, Guid>, DefaultCommandRepository<LearningSession, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<LearningSession, Guid>, DefaultQueryRepository<LearningSession, LearningSessionsDbContext, Guid>>()
            .AddScoped<ICommandRepository<Trainee, Guid>, DefaultCommandRepository<Trainee, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<Trainee, Guid>, DefaultQueryRepository<Trainee, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<User, Guid>, DefaultQueryRepository<User, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<Mentor, Guid>, DefaultQueryRepository<Mentor, LearningSessionsDbContext, Guid>>()
            .AddScoped<ICommandRepository<Skill, Guid>, DefaultCommandRepository<Skill, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<Skill, Guid>, DefaultQueryRepository<Skill, LearningSessionsDbContext, Guid>>()
            .AddScoped<IQueryRepository<Technology, Guid>, DefaultQueryRepository<Technology, LearningSessionsDbContext, Guid>>();


        return services;
    }
}
