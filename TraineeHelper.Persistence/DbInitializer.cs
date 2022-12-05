namespace TraineeHelper.Persistence;
public class DbInitializer
{
    public static void Initialize(TraineesDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}
