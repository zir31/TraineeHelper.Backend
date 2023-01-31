using System;

namespace TraineeHelper.Domain
{
    public class Trainee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Mentor? Mentor { get; set; }
        public IEnumerable<PersonalSkill> PersonalSkills { get; set; }

        private List<LearningSession> _learningSessions;
        public int? ActiveLearningSessionId { get; set; }
        public LearningSession? ActiveLearningSession { get; set; }
        public ICollection<LearningSession> LearningSessions { get; set; }
        public Grade Grade { get; set; }

        public Trainee(string fullName, Technology technology, IEnumerable<PersonalSkill> personalSkills)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            _learningSessions = new List<LearningSession>();
            PersonalSkills = personalSkills;
            Grade = new Grade(){Name = "Trainee" ,Technology = technology};
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
