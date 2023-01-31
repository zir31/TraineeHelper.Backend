using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Status;
public abstract class LearningSessionState
{
    abstract public string Name { get; set; }
    public virtual void SendToMentor(LearningSession learningSession)
    {
        learningSession.State = new ReviewState();
        learningSession.StateType = Name;
    }
    public virtual void EndSession(LearningSession learningSession)
    {
        learningSession.State = new DoneState();
        learningSession.StateType = Name;
    }
}
