using MediatR;

namespace TraineeHelper.Application.Commands;

public record CreateSkillCommand : IRequest<SkillResponse>
{
    //public Guid MentorId { get; init; }
    public string SkillName { get; init; }
    public Guid TechnologyId { get; init; }

}

