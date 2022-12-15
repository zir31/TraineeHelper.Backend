using MediatR;
using System;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
public class UpdateLearningSessionCommand : IRequest
{
    public Guid TraineeId { get; set; }
    public Guid Id { get; set; }
    public string TraineeName { get; set; }
    //public Dictionary<string, bool> SkillsLearned { get; set; }
    public List<Skill> SkillsToLearn { get; set; }
    public List<Skill> SkillsLearned { get; set; }
}
