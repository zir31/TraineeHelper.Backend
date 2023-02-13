using MediatR;
using TraineeHelper.Domain.Status;

namespace TraineeHelper.Application.Commands;
public record UpdateLearningSessionCommand : IRequest<LearningSessionResponse>
{
    public Guid Id { get; init; }
    //public Trainee Trainee { get; init; } = null!;
    public LearningSessionState LearningSessionState { get; init; } = null!;
    public List<Guid> SkillsLearnedIds { get; init; } = null!;
}
