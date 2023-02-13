using MediatR;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Domain.Contracts;
using AutoMapper;

namespace TraineeHelper.Application.Commands;
public class DeleteLearningSessionCommandHandler
    : IRequestHandler<DeleteLearningSessionCommand, LearningSessionResponse>
{
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly ICommandRepository<LearningSession, Guid> _lsRepository;
    private readonly IMapper _mapper;
    public DeleteLearningSessionCommandHandler(ICommandRepository<LearningSession, Guid> commandRepository, IMapper mapper)
    {
        _lsRepository = commandRepository;
        _mapper = mapper;
    }

    public async Task<LearningSessionResponse> Handle(DeleteLearningSessionCommand request,
        CancellationToken cancellationToken)
    {
        //var entity = await _dbContext.LearningSessions
        //    .FindAsync(new object[] { request.Id }, cancellationToken);
        var entity = await _lsRepository.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entity == null || entity.TraineeId != request.TraineeId)
            throw new NotFoundException(nameof(LearningSession), request.Id);

        //_dbContext.LearningSessions.Remove(entity);
        //await _dbContext.SaveChangesAsync(cancellationToken);
        var response = _lsRepository.DeleteAsync(entity);
        await _lsRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<LearningSessionResponse>(response);
    }
}
