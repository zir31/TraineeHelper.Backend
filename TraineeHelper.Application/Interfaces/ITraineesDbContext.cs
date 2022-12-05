using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineeHelper.Domain;

namespace TraineeHelper.Application.Interfaces
{
    public interface ITraineesDbContext
    {
        DbSet<Trainee> Trainees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
