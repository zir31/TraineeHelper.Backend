using System;
using FluentValidation;

namespace TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
public class UpdateLearningSessionCommandValidator : AbstractValidator<UpdateLearningSessionCommand>
{
    public UpdateLearningSessionCommandValidator()
    {
        RuleFor(updateLSCommand =>
            updateLSCommand.TraineeId).NotEqual(Guid.Empty);
        RuleFor(updateLSCommand =>
            updateLSCommand.Id).NotEqual(null);
        RuleFor(createLSCommand =>
            createLSCommand.SkillsLearned).NotEmpty();
    }
}
