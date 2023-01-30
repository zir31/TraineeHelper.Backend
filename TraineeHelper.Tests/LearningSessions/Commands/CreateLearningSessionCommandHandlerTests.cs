//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
//using TraineeHelper.Domain;
//using TraineeHelper.Tests.Common;
//using Xunit;

//namespace TraineeHelper.Tests.LearningSessions.Commands;
//public class CreateLearningSessionCommandHandlerTests : TestCommandBase
//{
//    [Fact]
//    public async Task CreateLearningSessionCommandHandler_Success()
//    {
//        //Arrange
//        var handler = new CreateLearningSessionCommandHandler(_context);
//        var traineeName = "trainee name";
//        var skillsToLearn = new List<PersonalSkill>() { new PersonalSkill() { Id = 0, Name = "Sample Technology" } };

//        // Act
//        var sessionId = await handler.Handle(
//            new CreateLearningSessionCommand
//            {
//                Trainee = new Trainee("Alex",null),
//                SkillsToLearn = skillsToLearn,
//            },
//            CancellationToken.None) ;

//        // Assert
//        Assert.NotNull(
//            await _context.LearningSessions.AsNoTracking().SingleOrDefaultAsync(ls =>
//                ls.Id == sessionId));
//    }
//}
