using System;
using FluentValidation;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateSkill;
public class CreateSkillCommandValidator :AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(createLSCommand =>
            createLSCommand.Mentor.Id).NotEqual(Guid.Empty);
        RuleFor(createLSCommand =>
            createLSCommand.SkillName).NotEmpty();
    }
}
