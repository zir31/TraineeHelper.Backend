using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.Interfaces;
public interface ILearningSessionsDbContext
{
    DbSet<LearningSession> LearningSessions { get; set; }
    DbSet<Skill> Skills { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
