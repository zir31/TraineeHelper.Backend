using MediatR;
using TraineeHelper.Application.Commands;

namespace TraineeHelper.Application.Queries;
public record GetLearningSessionsListQuery : IRequest<IEnumerable<LearningSessionResponse>>
{
    public Guid TraineeId { get; init; }
    //public IEnumerable<LearningSession> LearningSessions { get; set; }
}
