﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Entities;
public class Grade
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Technology Technology { get; set; }

    public ICollection<RequiredSkill> RequiredSkills { get; set; }
    public ICollection<Trainee> Trainees { get; set; }
}