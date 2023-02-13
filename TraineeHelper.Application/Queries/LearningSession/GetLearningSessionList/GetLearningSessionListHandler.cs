using AutoMapper;
using MediatR;
using TraineeHelper.Application.Commands;
using TraineeHelper.Domain.Entities;
using TraineeHelper.Persistence.Abstractions;

namespace TraineeHelper.Application.Queries;
public class GetLearningSessionListQueryHandler : IRequestHandler<GetLearningSessionsListQuery, IEnumerable<LearningSessionResponse>>
{
    //private readonly ILearningSessionsDbContext _dbContext;
    private readonly IQueryRepository<LearningSession, Guid> _lsRepository;
    private readonly IMapper _mapper;
    public GetLearningSessionListQueryHandler(IQueryRepository<LearningSession, Guid> queryRepository, IMapper mapper)
    {
        //_dbContext = dbContext;
        _lsRepository = queryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LearningSessionResponse>> Handle(GetLearningSessionsListQuery request,
        CancellationToken cancellationToken)
    {

        //var lsQuery = await _dbContext.LearningSessions
        //    .Where(ls => ls.Trainee.Id == request.TraineeId)
        //    .ProjectTo<LearningSessionLookupDTO>(_mapper.ConfigurationProvider)
        //    .ToListAsync(cancellationToken);

        var lsQuery = await _lsRepository.FindAsync(e => e.TraineeId == request.TraineeId);

        //return new LearningSessionListVm { LearningSessions = lsQuery };
        return _mapper.Map<IEnumerable<LearningSessionResponse>>(lsQuery);
    }
}
