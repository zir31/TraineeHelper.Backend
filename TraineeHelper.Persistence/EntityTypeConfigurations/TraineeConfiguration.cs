using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeHelper.Domain;

namespace TraineeHelper.Persistence.EntityTypeConfigurations;
public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
{
    public void Configure(EntityTypeBuilder<Trainee> builder)
    {
        builder.HasMany(trainee => trainee.LearningSessions)
            .WithOne(ls => ls.Trainee);

        builder.HasOne(trainee => trainee.ActiveLearningSession)
            .WithOne()
            .HasForeignKey<Trainee>(trainee => trainee.ActiveLearningSessionId);
        //builder.HasKey(ls => ls.Id);
        //builder.HasIndex(ls => ls.Id).IsUnique();
        //builder.Property(ls => ls.SkillsLearned).HasMaxLength(250);
    }
}
