using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class LearningSession
{
    public Guid Id { get; set; }
    //public Guid TraineeId { get; set; }
    //public string TraineeName { get; set; }
    public Trainee Trainee { get; set; }
    public DateTime CreationDate { get; set; }
    //public DateTime? EditDate { get; set; }
    public DateTime? FinishingDate { get; set; }
    public Mentor? Mentor { get; set; }
    //public LearningSessionStatus Status { get; set; }
    public virtual IEnumerable<Skill> SkillsToLearn { get; set; }
    public virtual IEnumerable<Skill> SkillsLearned { get; set; }
}
