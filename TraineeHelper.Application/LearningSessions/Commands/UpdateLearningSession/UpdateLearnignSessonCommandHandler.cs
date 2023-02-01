using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
public class UpdateLearnignSessonCommandHandler 
    : IRequestHandler<UpdateLearningSessionCommand>
{
    private readonly ILearningSessionsDbContext _dbContext;
    public UpdateLearnignSessonCommandHandler(ILearningSessionsDbContext learningSessionsDbContext) =>
        _dbContext = learningSessionsDbContext;
    public async Task<Unit> Handle(UpdateLearningSessionCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.LearningSessions.FirstOrDefaultAsync(ls => 
            ls.Id == request.Id, cancellationToken);

        if (entity == null || entity.Trainee.Id != request.Trainee.Id)
            throw new NotFoundException(nameof(LearningSession), request.Id);

        //TODO update entity
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
