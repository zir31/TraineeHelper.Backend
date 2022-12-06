using MediatR;
using System;

namespace TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
public class UpdateLearningSessionCommand : IRequest
{
    public Guid TraineeId { get; set; }
    public Guid Id { get; set; }
    public string TraineeName { get; set; }
    public Dictionary<string, bool> SkillsLearned { get; set; }
}
