using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class Mentor
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public IEnumerable<ApprovedSkill> ApprovedSkills { get; set; }
    public IEnumerable<LearningSession> LearningSessions { get; set; }
    public IEnumerable<Trainee> Trainees { get; set; }
}
