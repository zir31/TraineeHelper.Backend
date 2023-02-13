using MediatR;

namespace TraineeHelper.Application.Commands;

//TODO+ Change to records
//get private set
public record CreateLearningSessionCommand : IRequest<LearningSessionResponse>
{
    public Guid TraineeId { get; init; }
    public List<Guid> SkillsToLearnIds { get; init; } = null!;


}

