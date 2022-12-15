using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public enum LevelOfKnowledge
{
    None, Novice, Intern, Advanced
}
public class ApprovedSkill
{
    public int ApprovedSkillID { get; set; }
    public int SkillId { get; set; }
    public int TraineeId { get; set; }
    public LevelOfKnowledge LevelOfKnowledge { get; set; }

    public virtual Skill Skill { get; set; }
    public virtual Trainee Trainee { get; set; }
}
