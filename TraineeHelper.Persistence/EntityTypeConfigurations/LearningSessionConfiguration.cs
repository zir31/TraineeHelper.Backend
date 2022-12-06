using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeHelper.Domain;

namespace TraineeHelper.Persistence.EntityTypeConfigurations;
public class LearningSessionConfiguration : IEntityTypeConfiguration<LearningSession>
{
    public void Configure(EntityTypeBuilder<LearningSession> builder)
    {
        builder.HasKey(ls => ls.Id);
        builder.HasIndex(ls => ls.Id).IsUnique();
        builder.Property(ls => ls.SkillsLearned).HasMaxLength(250);
    }
}
