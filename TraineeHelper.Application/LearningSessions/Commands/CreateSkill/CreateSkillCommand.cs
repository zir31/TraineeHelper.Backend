using System;
using MediatR;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.LearningSessions.Commands.CreateSkill
{
    public class CreateSkillCommand : IRequest<int>
    {
        public Mentor Mentor { get; set; }
        public string SkillName { get; set; }
        public Technology Technology { get; set; }

    }
}

