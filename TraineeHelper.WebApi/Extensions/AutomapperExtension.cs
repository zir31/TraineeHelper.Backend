using TraineeHelper.WebApi.Mapping;

namespace TraineeHelper.WebApi.Extensions;

/// <summary>
/// Extension for register Automapper profiles
/// </summary>
internal static class AutomapperExtension
{
    public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services)
    {
        Type[] profilesCollection =
        {
            typeof(SkillMap),
            typeof(LearningSessionMap),
        };

        services.AddAutoMapper(profilesCollection);

        return services;
    }
}
