using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Domain.Status;
public class DoneState : LearningSessionState
{
    public override string Name { get { return "Done"; } set { } }
    //forbidden for everyone
    public override void EndSession(LearningSession learningSession)
    {
        throw new InvalidOperationException("Learning session is already closed");
    }

    //forbidden for everyone
    public override void SendToMentor(LearningSession learningSession)
    {
        throw new InvalidOperationException("Learning session is closed");
    }
}
