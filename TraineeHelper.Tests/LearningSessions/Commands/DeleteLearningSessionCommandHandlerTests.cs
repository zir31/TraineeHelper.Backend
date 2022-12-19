using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
using TraineeHelper.Tests.Common;

namespace TraineeHelper.Tests.LearningSessions.Commands;
public class DeleteLearningSessionCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteLearningSessionCommandHandler_Success()
    {
        //Arrange
        var handler = new DeleteLearningSessionCommandHandler(_context);
        var createHandler = new CreateLearningSessionCommandHandler(_context);

        //Act
        var createHandlerId = await createHandler.Handle(new CreateLearningSessionCommand
        {
            Trainee = LearningSessionsContextFactory.Trainee1
        }, CancellationToken.None);
        await handler.Handle(new DeleteLearningSessionCommand
        {
            Id = createHandlerId,
            TraineeId = LearningSessionsContextFactory.Trainee1.Id
        }, CancellationToken.None);

        //Assert
        Assert.Null(_context.LearningSessions.SingleOrDefault(ls =>
        ls.Id == createHandlerId));
    }

    [Fact]
    public async Task DeleteLearningSessionCommandHandler_FailOnWrongId()
    {
        //Arrange
        var handler = new DeleteLearningSessionCommandHandler(_context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        await handler.Handle(
            new DeleteLearningSessionCommand
            {
                Id = Guid.NewGuid(),
                TraineeId = LearningSessionsContextFactory.UserAId
            },
            CancellationToken.None));
    }

    [Fact]
    public async Task DeleteLearningSessionCommandHandler_FailOnWrongUserId()
    {
        // Arrange
        var deleteHandler = new DeleteLearningSessionCommandHandler(_context);
        var createHandler = new CreateLearningSessionCommandHandler(_context);
        var traineeId = await createHandler.Handle(
            new CreateLearningSessionCommand
            {
                Trainee = LearningSessionsContextFactory.Trainee2
            }, CancellationToken.None);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteLearningSessionCommand
                {
                    Id = traineeId,
                    TraineeId = LearningSessionsContextFactory.UserBId
                }, CancellationToken.None));
    }
}
