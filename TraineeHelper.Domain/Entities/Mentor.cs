using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Entities;
public class Mentor : User
{
    public string FullName { get; set; }
    public IEnumerable<PersonalSkill> PersonalSkills { get; set; }
    public IEnumerable<LearningSession> LearningSessions { get; set; }
    public IEnumerable<Trainee> Trainees { get; set; }


}
