using MediatR;
using System;
using TraineeHelper.Domain;
using TraineeHelper.Domain.Status;

namespace TraineeHelper.Application.LearningSessions.Commands.UpdateLearningSession;
public class UpdateLearningSessionCommand : IRequest
{
    public int Id { get; set; }
    public Trainee Trainee { get; set; }
    public LearningSessionState LearningSessionState { get; set; }
    public List<PersonalSkill> SkillsLearned{ get; set; }
}
