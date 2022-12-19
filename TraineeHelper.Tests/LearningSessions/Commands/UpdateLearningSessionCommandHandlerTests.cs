using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
using TraineeHelper.Tests.Common;

namespace TraineeHelper.Tests.LearningSessions.Commands;
public class UpdateLearningSessionCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateLearningSessionCommandHandler_Success()
        {
            // Arrange
            var createHandler = new CreateLearningSessionCommandHandler(_context);
            var updateHandler = new UpdateLearnignSessonCommandHandler(_context);
            var updatedTraineeName = "Cool Trainee";

        // Act
            var createHandlerId = await createHandler.Handle(new CreateLearningSessionCommand
            {
                Trainee = LearningSessionsContextFactory.Trainee1
            }, CancellationToken.None);
            await updateHandler.Handle(new UpdateLearningSessionCommand
            {
                Id = createHandlerId,
                TraineeId = LearningSessionsContextFactory.Trainee1.Id,
                TraineeName = updatedTraineeName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await _context.LearningSessions.SingleOrDefaultAsync(ls =>
                ls.Id == createHandlerId &&
                ls.Trainee.FullName == updatedTraineeName));
        }

    [Fact]
    public async Task UpdateLearningSessionCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateLearnignSessonCommandHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateLearningSessionCommand
                    {
                        Id = Guid.NewGuid(),
                        TraineeId = LearningSessionsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

    [Fact]
    public async Task UpdateLearningSessionCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateLearnignSessonCommandHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateLearningSessionCommand
                    {
                        Id = LearningSessionsContextFactory.LearningSessionIdForUpdate,
                        TraineeId = LearningSessionsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
