using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
public class DeleteLearningSessionCommandHandler
    : IRequestHandler<DeleteLearningSessionCommand>
{
    private readonly ILearningSessionsDbContext _dbContext;
    public DeleteLearningSessionCommandHandler(ILearningSessionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteLearningSessionCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.LearningSessions
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.TraineeId != request.TraineeId)
            throw new NotFoundException(nameof(LearningSession), request.Id);

        _dbContext.LearningSessions.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
