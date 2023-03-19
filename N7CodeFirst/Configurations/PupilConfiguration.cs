using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N7CodeFirst.Configurations
{
    public class PupilConfiguration : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.ToTable("Pupil", "school");
            builder.Property(x => x.FirstName)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasMaxLength(50);
            builder.Property(x => x.Class)
               .HasMaxLength(50);
            builder.Property(x => x.Gender)
            .HasMaxLength(10)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (Gender)Enum.Parse(typeof(Gender), v, true));
        }
    }
}
