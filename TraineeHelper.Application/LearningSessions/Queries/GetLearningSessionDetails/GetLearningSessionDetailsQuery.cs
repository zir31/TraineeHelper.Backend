using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionDetails;
public class GetLearningSessionDetailsQuery : IRequest<LearningSessionDetailsVm>
{
    public Guid TraineeId { get; set; }
    public Guid Id { get; set; }
}
