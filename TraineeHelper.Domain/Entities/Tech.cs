using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain.Contracts;

namespace TraineeHelper.Domain.Entities;
public class Technology : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Skill> Skills { get; set; }
}
