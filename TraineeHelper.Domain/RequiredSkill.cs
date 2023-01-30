using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class RequiredSkill
{
    public int RequiredSkillId { get; set; }
    public int SkillId { get; set; }
    public LevelOfKnowledge LevelOfKnowledge { get; set; }
    public Grade Grade { get; set; }
}
