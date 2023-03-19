using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace N7CodeFirst.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher", "school");
            builder.Property(x => x.FirstName)
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .HasMaxLength(50);
            builder.Property(x => x.Subject)
               .HasMaxLength(50);
            builder.Property(x => x.Gender)
            .HasMaxLength(10)
            .IsRequired()
            .HasDefaultValue(Gender.Female)
            .HasConversion(
                v => v.ToString(),
                v => (Gender)Enum.Parse(typeof(Gender), v, true));
        }
    }
}