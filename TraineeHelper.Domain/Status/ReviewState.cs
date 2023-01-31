using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Domain.Status;
public class ReviewState : LearningSessionState
{
    public override string Name { get { return "Review"; } set { } }
    //authorized by trainee role
    public override void SendToMentor(LearningSession learningSession)
    {
        throw new InvalidOperationException("Learning session already in Review State");
    }
}
