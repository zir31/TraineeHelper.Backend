using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Domain;
using TraineeHelper.Persistence;

namespace TraineeHelper.Tests.Common;
public class LearningSessionsContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();

    public static Guid LearningSessionIdForUpdate= Guid.NewGuid();
    public static Guid LearningSessionIdForDelete= Guid.NewGuid();

    public static Trainee Trainee1 = new Trainee("Alex", null);
    public static Trainee Trainee2 = new Trainee("Boris", null);

    public static List<Skill> SampleSkills = new List<Skill>() 
    { 
        new Skill 
        { 
            Id = 777, 
            Name = "Domain Driven Design" 
        },
        new Skill
        {
            Id = 1,
            Name = "Domain Driven Design"
        },
        new Skill
        {
            Id = 2,
            Name = "Клиент-серверная архитектура"
        },
        new Skill
        {
            Id = 3,
            Name = "Вертикальное и горизонтальное масштабирование"
        },
        new Skill
        {
            Id = 4,
            Name = "Lorem ipsum"
        }
    };

    public static LearningSessionsDbContext Create()
    {
        var options = new DbContextOptionsBuilder<LearningSessionsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            
            .EnableSensitiveDataLogging()
            .Options;
        var context = new LearningSessionsDbContext(options);
        context.Database.EnsureCreated();
        //Trainee1.CreateLearningSession(SampleSkills);
        context.Skills.AddRange(SampleSkills
            );
        Trainee1.CreateLearningSession(SampleSkills);
        context.LearningSessions.Add(new LearningSession
        {
            Id = LearningSessionIdForDelete,
            Trainee = Trainee2,
            SkillsToLearn = SampleSkills
        });
        //context.LearningSessions.AddRange(
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        SkillsLearned = new List<Skill>(),

        //        //Id = Guid.Parse("{B9B78344-7185-4328-AAE2-16FA69F34CB4}"),
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee1
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        SkillsLearned = new List<Skill>()
        //        {
        //            new Skill(){Id = 2, Name="Domain Driven Design"}
        //        },
        //        Id = Guid.NewGuid(),
        //        Trainee = Trainee2
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        SkillsLearned = new List<Skill>()
        //        {
        //            new Skill(){Id = 3, Name="Domain Driven Design"}
        //        },
        //        Id = LearningSessionIdForDelete,
        //        Trainee = Trainee1
        //    },
        //    new LearningSession
        //    {
        //        CreationDate = DateTime.Today,
        //        SkillsLearned = new List<Skill>()
        //        {
        //            new Skill(){Id = 4, Name="Domain Driven Design"}
        //        },
        //        Id = LearningSessionIdForUpdate,
        //        Trainee = Trainee2
        //    });
        context.SaveChanges();
        return context;
    }

    public static void Destroy(LearningSessionsDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }

}
