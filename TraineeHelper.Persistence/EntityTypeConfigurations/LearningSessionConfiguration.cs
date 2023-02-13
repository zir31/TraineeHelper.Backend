using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Persistence.EntityTypeConfigurations;
public class LearningSessionConfiguration : IEntityTypeConfiguration<LearningSession>
{
    public void Configure(EntityTypeBuilder<LearningSession> builder)
    {
        //TODO add all+ 
        builder.HasKey(ls => ls.Id);
        builder.HasIndex(ls => ls.Id).IsUnique();
        builder.Ignore(ls => ls.State);
        builder.Property(ls => ls.TraineeId).IsRequired();
        builder.Property(ls => ls.MentorId);
        builder.Property(ls => ls.CreationDate).IsRequired();
        builder.Property(ls => ls.FinishingDate);

        //builder.ToTable(nameof(LearningSession)); 
    }
}
