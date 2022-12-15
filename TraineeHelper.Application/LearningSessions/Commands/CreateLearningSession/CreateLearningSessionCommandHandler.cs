using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession;
public class CreateLearningSessionCommandHandler 
    : IRequestHandler<CreateLearningSessionCommand, Guid>
{
    private readonly ILearningSessionsDbContext _dbContext;
    public CreateLearningSessionCommandHandler(ILearningSessionsDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateLearningSessionCommand command, 
        CancellationToken cancellationToken)
    {
        var learningSession = new LearningSession()
        {
            Id = Guid.NewGuid(),
            TraineeId = command.TraineeId,
            //SkillsToLearn = command.SkillsToLearn,
            SkillsLearned = command.SkillsLearned,
            CreationDate = DateTime.Now,
            FinishingDate = null
        };
        await _dbContext.LearningSessions.AddAsync(learningSession, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return learningSession.Id;
    }
}
