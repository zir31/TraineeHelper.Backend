using Microsoft.EntityFrameworkCore;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Domain;
using TraineeHelper.Persistence.EntityTypeConfigurations;

namespace TraineeHelper.Persistence;
public class LearningSessionsDbContext : DbContext, ILearningSessionsDbContext
{
    public DbSet<LearningSession> LearningSessions { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<ApprovedSkill> ApprovedSkills { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public LearningSessionsDbContext(DbContextOptions<LearningSessionsDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new LearningSessionConfiguration());
        base.OnModelCreating(builder);
    }
}
