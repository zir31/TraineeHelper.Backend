using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain.Contracts;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Application.Commands;
public class UpdateLearnignSessonCommandHandler
    : IRequestHandler<UpdateLearningSessionCommand, LearningSessionResponse>
{
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly ICommandRepository<LearningSession, Guid> _lsRepository;
    private readonly IMapper _mapper;

    public UpdateLearnignSessonCommandHandler(ICommandRepository<LearningSession, Guid> lsRepository, IMapper mapper)
    {
        _lsRepository = lsRepository;
        _mapper = mapper;
    }


    //public UpdateLearnignSessonCommandHandler(ILearningSessionsDbContext learningSessionsDbContext) =>
    //    _dbContext = learningSessionsDbContext;
    public async Task<LearningSessionResponse> Handle(UpdateLearningSessionCommand request, CancellationToken cancellationToken)
    {
        //var entity =
        //    await _dbContext.LearningSessions.FirstOrDefaultAsync(ls => 
        //    ls.Id == request.Id, cancellationToken);
        var entity = await _lsRepository.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


        if (entity == null)
            throw new NotFoundException(nameof(LearningSession), request.Id);

        //TODO update entity+
        //await _dbContext.SaveChangesAsync(cancellationToken);
        var response = _lsRepository.UpdateAsync(entity);
        await _lsRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<LearningSessionResponse>(response);
    }
}
