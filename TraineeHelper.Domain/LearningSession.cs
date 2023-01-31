using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain.Status;

namespace TraineeHelper.Domain;
public class LearningSession
{
    public int Id { get; private set; }
    public Trainee Trainee { get; set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? FinishingDate { get; private set; }
    public Mentor? Mentor { get; private set; }
    public LearningSessionState State { get; set; }
    public string StateType { get; set; }
    public bool IsActive { get; private set; }
    public ICollection<PersonalSkill> PersonalSkills { get; set; }
    private LearningSessionState _learningSessionState;

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
        State = new LearningState();
        StateType = State.Name;
    }

    private LearningSession()
    {

    }
}
