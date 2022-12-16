using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class LearningSession
{
    public Guid Id { get; set; }
    public Guid TraineeId { get; set; }
    public string TraineeName { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
    public DateTime? FinishingDate { get; set; }
    //public virtual ICollection<Skill> SkillsToLearn { get; set; }
    public virtual IEnumerable<Skill> SkillsLearned { get; set; }
}
