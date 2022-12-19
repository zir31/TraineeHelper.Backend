using System;

namespace TraineeHelper.Domain
{
    public class Trainee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Tech Technology { get; set; }
        public IEnumerable<ApprovedSkill> ApprovedSkills { get; set; }
        
        public Mentor Mentor { get; set; }

        private List<LearningSession> _learningSessions;
        public IReadOnlyList<LearningSession> LearningSessions => _learningSessions;

        public Trainee(string fullName, IEnumerable<ApprovedSkill> approvedSkills)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            _learningSessions = new List<LearningSession>();
            ApprovedSkills = approvedSkills;
        }
        public Trainee()
        {

        }
        public void CreateLearningSession(IEnumerable<Skill> skillsToLearn)
        {
            _learningSessions.Add(new LearningSession()
            {
                Id = Guid.NewGuid(),
                Trainee = this,
                CreationDate = DateTime.Today,
                FinishingDate = null,
                Mentor = Mentor,
                SkillsToLearn = skillsToLearn
            });
        }
    }
}
