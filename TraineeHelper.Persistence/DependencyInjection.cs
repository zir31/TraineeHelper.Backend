using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraineeHelper.Application.Interfaces;

namespace TraineeHelper.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ILearningSessionsDbContext, LearningSessionsDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            options.EnableSensitiveDataLogging(true);
        });
        //services.AddScoped<ILearningSessionsDbContext>(provider =>
        //    provider.GetService<LearningSessionsDbContext>());
        return services;
    }
}
