using N7CodeFirst;

    public class Pupil
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Class { get; set; }
        public ICollection<TeacherPupil> TeacherPupils { get; set; }
    }
