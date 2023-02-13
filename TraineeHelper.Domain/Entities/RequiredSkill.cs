using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Entities;
public class RequiredSkill
{
    public Guid RequiredSkillId { get; set; }
    public Guid SkillId { get; set; }
    public LevelOfKnowledge LevelOfKnowledge { get; set; }
    public Grade Grade { get; set; }
}
