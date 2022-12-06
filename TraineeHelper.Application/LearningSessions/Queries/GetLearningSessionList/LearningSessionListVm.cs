using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Application.LearningSessions.Queries.GetLearningSessionList;
public class LearningSessionListVm
{
    public IList<LearningSessionLookupDTO> LearningSessions { get; set; }
}
