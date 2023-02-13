using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeHelper.Application.Queries;
public class LearningSessionListVm
{
    public IList<LearningSessionLookupDTO> LearningSessions { get; set; }
}
