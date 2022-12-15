using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ApprovedSkill> ApprovedSkills { get; set; }
}
