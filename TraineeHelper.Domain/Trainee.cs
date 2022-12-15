using System;

namespace TraineeHelper.Domain
{
    public class Trainee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<ApprovedSkill> ApprovedSkills { get; set; }
    }
}
