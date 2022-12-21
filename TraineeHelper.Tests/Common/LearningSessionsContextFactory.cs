using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using TraineeHelper.Domain;
using TraineeHelper.Persistence;

namespace TraineeHelper.Tests.Common;
public class LearningSessionsContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();

    public static Guid LearningSessionIdForUpdate= Guid.NewGuid();
    public static Guid LearningSessionIdForDelete= Guid.NewGuid();

    //public static Trainee Trainee1 = new Trainee("Alex", null);
    //public static Trainee Trainee2 = new Trainee("Boris", null);

    //public static List<Skill> SampleSkills = new List<Skill>() 
    //{ 
    //    new Skill 
    //    { 
    //        Id = 777, 
    //        Name = "Domain Driven Design" 
    //    },
    //    new Skill
    //    {
    //        Id = 1,
    //        Name = "Domain Driven Design"
    //    },
    //    new Skill
    //    {
    //        Id = 2,
    //        Name = "Клиент-серверная архитектура"
    //    },
    //    new Skill
    //    {
    //        Id = 3,
    //        Name = "Вертикальное и горизонтальное масштабирование"
    //    },
    //    new Skill
    //    {
    //        Id = 4,
    //        Name = "Lorem ipsum"
    //    }
    //};

    public static LearningSessionsDbContext Create()
    {
        var options = new DbContextOptionsBuilder<LearningSessionsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;
        var context = new LearningSessionsDbContext(options);
        var Trainee1 = new Trainee("Alex", null) { Id = UserAId};
        var Trainee2 = new Trainee("Boris", null) { Id = UserBId};
        context.Database.EnsureCreated();
        //context.Skills.AddRange(SampleSkills);
        //Trainee1.CreateLearningSession(SampleSkills);
        context.LearningSessions.AddRange(
            new LearningSession
            {
                CreationDate = DateTime.Today,
                //Id = Guid.Parse("{B9B78344-7185-4328-AAE2-16FA69F34CB4}"),
                Id = Guid.NewGuid(),
                Trainee = Trainee1
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                Id = Guid.NewGuid(),
                Trainee = Trainee2
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                Id = LearningSessionIdForDelete,
                Trainee = Trainee1
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                Id = LearningSessionIdForUpdate,
                Trainee = Trainee2
            });
        context.SaveChanges();
        var contextFactoryMock = new Mock<IDbContextFactory<LearningSessionsDbContext>>();
        contextFactoryMock.Setup(factory => factory.CreateDbContext()).Returns(new LearningSessionsDbContext(options));
        return context;
    }

    public static void Destroy(LearningSessionsDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }

}
