using System;
using FluentValidation;

namespace TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
public class DeleteLearningSessionCommandValidator : AbstractValidator<DeleteLearningSessionCommand>
{
    public DeleteLearningSessionCommandValidator()
    {
        RuleFor(updateLSCommand =>
            updateLSCommand.TraineeId).NotEqual(Guid.Empty);
        RuleFor(updateLSCommand =>
            updateLSCommand.Id).NotEqual(null);
    }
}
