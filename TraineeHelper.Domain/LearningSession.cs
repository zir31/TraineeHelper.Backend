using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain;
public class LearningSession
{
    public int Id { get; private set; }
    public Trainee Trainee { get; set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? FinishingDate { get; private set; }
    public Mentor? Mentor { get; private set; }
    //public LearningSessionStatus Status { get; set; }
    public bool IsActive { get; private set; }
    public ICollection<PersonalSkill> PersonalSkills { get; set; }

    public LearningSession(Trainee trainee, ICollection<PersonalSkill> skillsToLearn)
    {
        if (trainee.ActiveLearningSession != null)
        {
            throw new ArgumentException("There already exist active learning session");
        }
        Trainee = trainee;
        CreationDate = DateTime.Today;
        Mentor = trainee.Mentor;
        IsActive = true;
        PersonalSkills = skillsToLearn;
        //PersonalSkills = new List<PersonalSkill>();
        //foreach(var skill in skillsToLearn)
        //{
        //    PersonalSkills.Add(new PersonalSkill(Trainee, skill));
        //}
    }

    private LearningSession()
    {

    }
}
