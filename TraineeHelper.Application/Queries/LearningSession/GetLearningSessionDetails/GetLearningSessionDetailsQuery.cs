using MediatR;
using TraineeHelper.Application.Commands;

namespace TraineeHelper.Application.Queries;
public record GetLearningSessionDetailsQuery : IRequest<LearningSessionResponse>
{
    public Guid TraineeId { get; init; }
    public Guid Id { get; init; }
}
