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

    public static LearningSessionsDbContext Create()
    {
        var options = new DbContextOptionsBuilder<LearningSessionsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new LearningSessionsDbContext(options);
        context.Database.EnsureCreated();
        context.LearningSessions.AddRange(
            new LearningSession
            {
                CreationDate = DateTime.Today,
                //SkillsLearned = new Dictionary<string, bool>() {
                //    { "Клиент-серверная архитектура", true },
                //    { "Вертикальное и горизонтальное масштабирование", true },
                //    { "Domain Driven Design", false }
                //},
                //SkillsToLearn = new List<Skill>()
                //{
                //    new Skill(){Id = 1, Name="Клиент-серверная архитектура"},
                //    new Skill(){Id = 2, Name="Вертикальное и горизонтальное масштабирование"}
                //},
                SkillsLearned = new List<Skill>()
                {
                    new Skill(){Id = 3, Name="Domain Driven Design"}
                },
                EditDate = null,
                Id = Guid.Parse("{B9B78344-7185-4328-AAE2-16FA69F34CB4}"),
                TraineeName = "Alex",
                TraineeId = UserAId
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                //SkillsLearned = new Dictionary<string, bool>() {
                //    { "Основы тестирования", false },
                //    { "Понятия: Mock, Stub, Fake", false },
                //    { "Интеграционное тестирование", false }
                //},
                //SkillsToLearn = new List<Skill>()
                //{
                //    new Skill(){Id = 1, Name="Клиент-серверная архитектура"},
                //    new Skill(){Id = 2, Name="Вертикальное и горизонтальное масштабирование"}
                //},
                SkillsLearned = new List<Skill>()
                {
                    new Skill(){Id = 3, Name="Domain Driven Design"}
                },
                EditDate = null,
                Id = Guid.Parse("{CA3BB9F3-E621-41C1-9140-AB823E0F6577}"),
                TraineeName = "Boris",
                TraineeId = UserBId
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                //SkillsLearned = new Dictionary<string, bool>() {
                //    { "Клиент-серверная архитектура", true },
                //    { "Вертикальное и горизонтальное масштабирование", true },
                //    { "Domain Driven Design", false }
                //},
                //SkillsToLearn = new List<Skill>()
                //{
                //    new Skill(){Id = 1, Name="Клиент-серверная архитектура"},
                //    new Skill(){Id = 2, Name="Вертикальное и горизонтальное масштабирование"}
                //},
                SkillsLearned = new List<Skill>()
                {
                    new Skill(){Id = 3, Name="Domain Driven Design"}
                },
                EditDate = null,
                Id = LearningSessionIdForDelete,
                TraineeName = "Alex",
                TraineeId = UserAId
            },
            new LearningSession
            {
                CreationDate = DateTime.Today,
                //SkillsLearned = new Dictionary<string, bool>() {
                //    { "Основы тестирования", false },
                //    { "Понятия: Mock, Stub, Fake", false },
                //    { "Интеграционное тестирование", false }
                //},
                //SkillsToLearn = new List<Skill>()
                //{
                //    new Skill(){Id = 1, Name="Клиент-серверная архитектура"},
                //    new Skill(){Id = 2, Name="Вертикальное и горизонтальное масштабирование"}
                //},
                SkillsLearned = new List<Skill>()
                {
                    new Skill(){Id = 3, Name="Domain Driven Design"}
                },
                EditDate = null,
                Id = LearningSessionIdForUpdate,
                TraineeName = "Boris",
                TraineeId = UserBId
            });
        context.SaveChanges();
        return context;
    }

    public static void Destroy(LearningSessionsDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }

}
