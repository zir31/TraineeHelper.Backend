using TraineeHelper.Domain;

namespace TraineeHelper.Persistence;
public class DbInitializer
{
    public static void Initialize(LearningSessionsDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();

        var defaultTrainee = new Trainee("Alex", new Technology() {Name = ".NET" }, new List<PersonalSkill>()) { Id = Guid.NewGuid() };
        dbContext.Trainees.Add(defaultTrainee);
        dbContext.SaveChanges();

        //defaultTrainee.CreateLearningSession(new List<Skill>());

        dbContext.SaveChanges();
    }
}
