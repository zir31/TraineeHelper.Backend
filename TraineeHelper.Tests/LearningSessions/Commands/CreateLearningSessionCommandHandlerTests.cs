using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Domain;
using TraineeHelper.Tests.Common;
using Xunit;

namespace TraineeHelper.Tests.LearningSessions.Commands;
public class CreateLearningSessionCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateLearningSessionCommandHandler_Success()
    {
        //Arrange
        var handler = new CreateLearningSessionCommandHandler(_context);
        var traineeName = "trainee name";
        var skillsLearned = new List<Skill>() { new Skill { Id = 0, Name = "Skill name" } };

        // Act
        var sessionId = await handler.Handle(
            new CreateLearningSessionCommand
            {
                TraineeName = traineeName,
                SkillsLearned = skillsLearned,
                TraineeId = LearningSessionsContextFactory.UserAId
            },
            CancellationToken.None) ;

        // Assert
        Assert.NotNull(
            await _context.LearningSessions.SingleOrDefaultAsync(ls =>
                ls.Id == sessionId && ls.TraineeName == traineeName));
    }
}
