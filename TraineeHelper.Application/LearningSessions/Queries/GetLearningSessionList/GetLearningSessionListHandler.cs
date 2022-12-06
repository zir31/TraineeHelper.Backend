using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Interfaces;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
public class GetLearningSessionListHandler : IRequestHandler<GetLearningSessionsListQuery, LearningSessionListVm>
{
    private readonly ILearningSessionsDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetLearningSessionListHandler(ILearningSessionsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LearningSessionListVm> Handle(GetLearningSessionsListQuery request,
        CancellationToken cancellationToken)
    {

        var lsQuery = await _dbContext.LearningSessions
            .Where(ls => ls.TraineeId == request.TraineeId)
            .ProjectTo<LearningSessionLookupDTO>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new LearningSessionListVm { LearningSessions = lsQuery };
    }
}
