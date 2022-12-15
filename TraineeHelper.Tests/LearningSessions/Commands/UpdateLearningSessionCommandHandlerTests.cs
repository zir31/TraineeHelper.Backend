using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
using TraineeHelper.Tests.Common;

namespace TraineeHelper.Tests.LearningSessions.Commands;
public class UpdateLearningSessionCommandHandlerTests : TestCommandBase
{
        [Fact]
        public async Task UpdateLearningSessionCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateLearnignSessonCommandHandler(_context);
            var updatedTraineeName = "Cool Trainee";

            // Act
            await handler.Handle(new UpdateLearningSessionCommand
            {
                Id = LearningSessionsContextFactory.LearningSessionIdForUpdate,
                TraineeId = LearningSessionsContextFactory.UserBId,
                TraineeName = updatedTraineeName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await _context.LearningSessions.SingleOrDefaultAsync(ls =>
                ls.Id == LearningSessionsContextFactory.LearningSessionIdForUpdate &&
                ls.TraineeName == updatedTraineeName));
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
