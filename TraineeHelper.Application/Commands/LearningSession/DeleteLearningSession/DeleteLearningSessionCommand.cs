using MediatR;

namespace TraineeHelper.Application.Commands;
public record DeleteLearningSessionCommand : IRequest<LearningSessionResponse>
{
    public Guid TraineeId { get; init; }
    public Guid Id { get; init; }
}
