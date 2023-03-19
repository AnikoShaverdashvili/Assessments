using Microsoft.EntityFrameworkCore;
using N7CodeFirst.Configurations;

namespace N7CodeFirst
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<TeacherPupil> TeacherPupils { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PupilConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherPupilConfiguration).Assembly);
        }

        //testing and adding Giorgi
        public static void SeedData(SchoolDbContext context)
        {
            // Check if teachers already exist
            var existingTeachers = context.Teachers.Any();
            if (!existingTeachers)
            {
                var teacher1 = new Teacher
                {
                    FirstName = "Aniko",
                    LastName = "Shaverdashvili",
                    Gender = Gender.Female,
                    Subject = "Biology"
                };

                var teacher2 = new Teacher
                {
                    FirstName = "Ana",
                    LastName = "Shav",
                    Gender = Gender.Other,
                    Subject = "Math"
                };

                var teacher3 = new Teacher
                {
                    FirstName = "TestTeacher3",
                    LastName = "TestTeacherSurname3",
                    Gender = Gender.Other,
                    Subject = "English"
                };

                context.Teachers.Add(teacher1);
                context.Teachers.Add(teacher2);
                context.Teachers.Add(teacher3);
            }

            // Check if pupils already exist
            var existingPupils = context.Pupils.Any();
            if (!existingPupils)
            {
                var pupil1 = new Pupil
                {
                    FirstName = "Giorgi",
                    LastName = "Test",
                    Gender = Gender.Male,
                    Class = "Grade 12"
                };
                var pupil2 = new Pupil
                {
                    FirstName = "Luka",
                    LastName = "lukadze",
                    Gender = Gender.Male,
                    Class = "Grade 11"
                };

                context.Pupils.Add(pupil1);
                context.Pupils.Add(pupil2);
            }

            // Add teacher-pupil relationships
            var giorgi = context.Pupils.FirstOrDefault(p => p.FirstName == "Giorgi");
            var luka = context.Pupils.FirstOrDefault(p => p.FirstName == "Luka");
            var teacheradd1 = context.Teachers.FirstOrDefault(t => t.FirstName == "Aniko");
            var teacheradd2 = context.Teachers.FirstOrDefault(t => t.FirstName == "Ana");
            var teacheradd3 = context.Teachers.FirstOrDefault(t => t.FirstName == "TestTeacher3");

            if (giorgi != null && teacheradd1 != null && teacheradd2 != null)
            {
                var existingRelationship = context.TeacherPupils
                    .FirstOrDefault(tp => tp.Teacher == teacheradd1 && tp.Pupil == giorgi);

                if (existingRelationship == null)
                {
                    var teacherPupil1 = new TeacherPupil
                    {
                        Teacher = teacheradd1,
                        Pupil = giorgi
                    };

                    context.TeacherPupils.Add(teacherPupil1);
                }

                existingRelationship = context.TeacherPupils
                    .FirstOrDefault(tp => tp.Teacher == teacheradd2 && tp.Pupil == giorgi);

                if (existingRelationship == null)
                {
                    var teacherPupil2 = new TeacherPupil
                    {
                        Teacher = teacheradd2,
                        Pupil = giorgi
                    };

                    context.TeacherPupils.Add(teacherPupil2);
                }
            }

            if (luka != null && teacheradd3 != null)
            {
                var existingRelationship = context.TeacherPupils
                    .FirstOrDefault(tp => tp.Teacher == teacheradd3 && tp.Pupil == luka);

                if (existingRelationship == null)
                {
                    var teacherPupil3 = new TeacherPupil
                    {
                        Teacher = teacheradd3,
                        Pupil = luka
                    };

                    context.TeacherPupils.Add(teacherPupil3);
                }
            }

            // Save changes
            context.SaveChanges();

        }

    }

}