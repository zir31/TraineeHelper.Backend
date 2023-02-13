using System;
using FluentValidation;

namespace TraineeHelper.Application.Commands;
public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        //RuleFor(createLSCommand =>
        //    createLSCommand.MentorId).NotEqual(Guid.Empty);
        RuleFor(createLSCommand =>
            createLSCommand.SkillName).NotEmpty();
    }
}
