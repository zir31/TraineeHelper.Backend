using AutoMapper;
using MediatR;
using TraineeHelper.Application.Commands;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Application.Queries;
public class GetLearningSessionDetailsQueryHandler
    : IRequestHandler<GetLearningSessionDetailsQuery, LearningSessionResponse>
{
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly IQueryRepository<LearningSession, Guid> _lsRepository;
    private readonly IMapper _mapper;
    public GetLearningSessionDetailsQueryHandler(IQueryRepository<LearningSession, Guid> queryRepository, IMapper mapper)
    {
        _lsRepository = queryRepository;
        _mapper = mapper;
    }

    public async Task<LearningSessionResponse> Handle(GetLearningSessionDetailsQuery request,
        CancellationToken cancellationToken)
    {
        //var entity = await _dbContext.LearningSessions
        //    .FirstOrDefaultAsync(ls => 
        //    ls.Id == request.Id, cancellationToken);
        var entity = await _lsRepository.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (entity == null || entity.TraineeId != request.TraineeId)
            throw new NotFoundException(nameof(LearningSession), request.Id);

        return _mapper.Map<LearningSessionResponse>(entity);
    }
}
