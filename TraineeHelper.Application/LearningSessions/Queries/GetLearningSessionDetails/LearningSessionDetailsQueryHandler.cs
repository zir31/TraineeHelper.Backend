using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Common.Exceptions;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
public class LearningSessionDetailsQueryHandler 
    : IRequestHandler<GetLearningSessionDetailsQuerry, LearningSessionDetailsVm>
{
    private readonly ILearningSessionsDbContext _dbContext;
    private readonly IMapper _mapper;
    public LearningSessionDetailsQueryHandler(ILearningSessionsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LearningSessionDetailsVm> Handle(GetLearningSessionDetailsQuerry request, 
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.LearningSessions
            .FirstOrDefaultAsync(ls => 
            ls.Id == request.Id, cancellationToken);

        if (entity == null || entity.TraineeId != request.TraineeId) 
            throw new NotFoundException(nameof(LearningSession), request.Id);

        return _mapper.Map<LearningSessionDetailsVm>(entity);
    }
}
