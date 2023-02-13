using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Entities;
public enum LevelOfKnowledge
{
    None, Novice, Intern, Advanced
}

public class PersonalSkill
{
    public Guid PersonalSkillId { get; set; }
    public Guid SkillId { get; set; }
    public Guid TraineeId { get; set; }
    public LevelOfKnowledge LevelOfKnowledge { get; set; }
    public bool IsLearned { get; set; }
    public bool IsApproved { get; set; }

    public Skill Skill { get; set; }
    public Trainee Trainee { get; set; }
    public LearningSession LearningSession { get; set; }

    public PersonalSkill(Trainee trainee, Skill skill)
    {
        SkillId = skill.Id;
        TraineeId = trainee.Id;
        LevelOfKnowledge = LevelOfKnowledge.None;
    }
    private PersonalSkill()
    {

    }
}
