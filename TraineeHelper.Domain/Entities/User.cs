using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain.Contracts;

namespace TraineeHelper.Domain.Entities;
public class User : IEntity<Guid>
{
    public Guid Id { get; set; }

}
