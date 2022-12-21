﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
using TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
using TraineeHelper.Domain;
using TraineeHelper.Tests.Common;

namespace TraineeHelper.Tests.LearningSessions.Commands;
public class DeleteLearningSessionCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteLearningSessionCommandHandler_Success()
    {
        //Arrange
        var handler = new DeleteLearningSessionCommandHandler(_context);
        await handler.Handle(new DeleteLearningSessionCommand
        {
            Id = LearningSessionsContextFactory.LearningSessionIdForDelete,
            TraineeId = LearningSessionsContextFactory.UserAId
        }, CancellationToken.None);

        //Assert
        Assert.Null(_context.LearningSessions.FirstOrDefault(ls =>
        ls.Id == LearningSessionsContextFactory.LearningSessionIdForDelete));
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
        var traineeId = Guid.NewGuid();
        var lsId = await createHandler.Handle(
            new CreateLearningSessionCommand
            {
                Trainee = new Trainee { Id = traineeId, FullName = "Cicero"}
            }, CancellationToken.None);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteLearningSessionCommand
                {
                    Id = lsId,
                    TraineeId = LearningSessionsContextFactory.UserBId
                }, CancellationToken.None));
    }
}
