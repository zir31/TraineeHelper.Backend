namespace TraineeHelper.Persistence;
public class DbInitializer
{
    public static void Initialize(LearningSessionsDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}
