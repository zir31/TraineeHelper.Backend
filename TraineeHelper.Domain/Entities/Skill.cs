using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain.Contracts;

namespace TraineeHelper.Domain.Entities;
public class Skill :IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TechnologyId { get; set; }
    public ICollection<PersonalSkill> PersonalSkills { get; set; }

    public Skill(string name, Technology technology)
    {
        Id = Guid.NewGuid();
        Name = name;
        TechnologyId = technology.Id;
    }
    private Skill()
    {

    }
}
