using System;
using MediatR;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession
{
    public class CreateLearningSessionCommand : IRequest<int>
    {
        public Trainee Trainee { get; set; }
        //public Guid TraineeId { get; set; }
        //public string TraineeName { get; set; }
        public List<PersonalSkill> SkillsToLearn { get; set; }
        //public List<Skill> SkillsLearned { get; set; }

    }
}

