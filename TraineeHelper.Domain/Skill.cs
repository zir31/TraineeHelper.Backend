﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Technology Technology { get; set; }
    public ICollection<PersonalSkill> PersonalSkills { get; set; }

    public Skill(string name, Technology technology)
    {
        Name = name;
        Technology = technology;
    }
    private Skill()
    {

    }
}
