using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Status;
public class LearningState : LearningSessionState
{
    public override string Name { get { return "Learning"; } set { } }
    //authorized by mentor role
    public override void EndSession(LearningSession learningSession)
    {
        throw new InvalidOperationException("Cannot end session in Learning state");
    }
}
