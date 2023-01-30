using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Application.LearningSessions.Commands.CreateSkill;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateSkillSession;
public class CreateSkillCommandHandler 
    : IRequestHandler<CreateSkillCommand, int>
{
    private readonly ILearningSessionsDbContext _dbContext;
    public CreateSkillCommandHandler(ILearningSessionsDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<int> Handle(CreateSkillCommand command, 
        CancellationToken cancellationToken)
    {
        var skill = new Skill(command.SkillName, command.Technology);
        await _dbContext.Skills.AddAsync(skill, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return skill.Id;
    }
}
