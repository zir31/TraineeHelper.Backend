using System;
using FluentValidation;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
public class CreateLearningSessionCommandValidator : AbstractValidator<CreateLearningSessionCommand>
{
    //Change to DTO Validation
    public CreateLearningSessionCommandValidator()
    {
        RuleFor(createLSCommand =>
            createLSCommand.Trainee.Id).NotEqual(Guid.Empty);
        RuleFor(createLSCommand =>
            createLSCommand.SkillsToLearn).NotEmpty();
    }
}
