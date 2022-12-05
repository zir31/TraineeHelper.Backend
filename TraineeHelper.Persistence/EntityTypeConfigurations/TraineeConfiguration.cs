using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeHelper.Domain;

namespace TraineeHelper.Persistence.EntityTypeConfigurations
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(trainee => trainee.Id);
            builder.HasIndex(trainee => trainee.Id).IsUnique();
            builder.Property(trainee => trainee.FullName).HasMaxLength(250);
        }
    }
}
