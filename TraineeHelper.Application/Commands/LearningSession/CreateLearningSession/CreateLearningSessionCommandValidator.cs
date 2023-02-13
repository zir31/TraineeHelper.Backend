using System;
using FluentValidation;

namespace TraineeHelper.Application.Commands;
public class CreateLearningSessionCommandValidator : AbstractValidator<CreateLearningSessionCommand>
{
    //Change to DTO Validation
    public CreateLearningSessionCommandValidator()
    {
        RuleFor(createLSCommand =>
            createLSCommand.TraineeId).NotEqual(Guid.Empty);
        RuleFor(createLSCommand =>
            createLSCommand.SkillsToLearnIds).NotEmpty();
    }
}
