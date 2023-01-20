using TraineeHelper.Domain;

namespace TraineeHelper.Persistence;
public class DbInitializer
{
    public static void Initialize(LearningSessionsDbContext dbContext)
    {
        //var Trainee1 = new Trainee("Alex", null) { Id = Guid.NewGuid() };
        //var Trainee2 = new Trainee("Boris", null) { Id = Guid.NewGuid() };
        dbContext.Database.EnsureCreated();

        //dbContext.LearningSessions.AddRange(
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee1
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee2
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee1
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee2
        //    });

        //dbContext.SaveChanges();
    }
}
