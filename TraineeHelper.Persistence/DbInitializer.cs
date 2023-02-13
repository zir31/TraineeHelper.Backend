using TraineeHelper.Domain;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Persistence;
public class DbInitializer
{
    public static void Initialize(LearningSessionsDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();

        var defaultTrainee = new Trainee("Alex", new Technology() {Name = ".NET" }, new List<PersonalSkill>()) { Id = Guid.NewGuid() };
        dbContext.Trainees.Add(defaultTrainee);
        dbContext.SaveChanges();

        var defaultMentor = new Mentor() { Id = Guid.NewGuid(), FullName = "Megamind" };
        dbContext.Mentors.Add(defaultMentor);
        dbContext.SaveChanges();
    }
}
