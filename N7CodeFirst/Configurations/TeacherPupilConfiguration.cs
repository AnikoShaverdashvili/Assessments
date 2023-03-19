using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N7CodeFirst.Configurations
{
    public class TeacherPupilConfiguration : IEntityTypeConfiguration<TeacherPupil>
    {
        public void Configure(EntityTypeBuilder<TeacherPupil> builder)
        {
            builder.ToTable("TeacherPupil", "school");

            builder.HasKey(tp => new { tp.TeacherId, tp.PupilId });

            builder.HasOne(tp => tp.Teacher)
                   .WithMany(t => t.TeacherPupils)
                   .HasForeignKey(tp => tp.TeacherId);

            builder.HasOne(tp => tp.Pupil)
                   .WithMany(p => p.TeacherPupils)
                   .HasForeignKey(tp => tp.PupilId);
        }
    }
}
