using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeHelper.Domain.Entities;

namespace TraineeHelper.Persistence.EntityTypeConfigurations;
public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasMany(skill => skill.PersonalSkills)
            .WithOne(ps => ps.Skill);

        
        //builder.HasKey(ls => ls.Id);
        //builder.HasIndex(ls => ls.Id).IsUnique();
        //builder.Property(ls => ls.SkillsLearned).HasMaxLength(250);
    }
}
