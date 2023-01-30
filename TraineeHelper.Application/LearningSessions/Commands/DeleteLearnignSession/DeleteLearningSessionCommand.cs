using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TraineeHelper.Application.LearningSessions.Commands.DeleteLearnignSession;
public class DeleteLearningSessionCommand : IRequest
{
    public Guid TraineeId { get; set; }
    public int Id { get; set; }
}
