using System;

namespace TraineeHelper.Domain.Entities
{
    public class Trainee : User
    {
        public string FullName { get; set; }
        public Guid? MentorId { get; set; }
        public Guid GradeId { get; set; }
        public Guid? ActiveLearningSessionId { get; set; }
        public LearningSession? ActiveLearningSession { get; set; }
        public ICollection<LearningSession> LearningSessions { get; set; }
        public ICollection<PersonalSkill> PersonalSkills { get; set; }


        private List<LearningSession> _learningSessions;

        public Trainee(string fullName, Technology technology, ICollection<PersonalSkill> personalSkills)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            _learningSessions = new List<LearningSession>();
            PersonalSkills = personalSkills;
            GradeId = new Grade() { Name = "Trainee", Technology = technology }.Id;
        }

        private Trainee()
        {

        }

        public void CreateLearningSession(ICollection<PersonalSkill> skillsToLearn)
        {
            _learningSessions.Add(new LearningSession(this, skillsToLearn));
        }

        public void MarkPersonalSkillsAsLearned(ICollection<PersonalSkill> personalSkills)
        {
            foreach (var skill in personalSkills)
            {
                if (!ActiveLearningSession.PersonalSkills.Contains(skill))
                {
                    throw new ArgumentException("skill is not in active learning session");
                }
                skill.IsLearned = true;
            }
        }

    }
}
