﻿using System;
using MediatR;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateLearningSession
{
    public class CreateLearningSessionCommand : IRequest<Guid>
    {
        public Guid TraineeId { get; set; }
        public string TraineeName { get; set; }
        //public Dictionary<string, bool> SkillsLearned { get; set; }
        public List<Skill> SkillsToLearn { get; set; }
        public List<Skill> SkillsLearned { get; set; }

    }
}

