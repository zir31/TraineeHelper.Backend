using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
public class GetLearningSessionsListQuery : IRequest<LearningSessionListVm>
{
    public Guid TraineeId { get; set; }
}
