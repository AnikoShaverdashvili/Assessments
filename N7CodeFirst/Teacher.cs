namespace N7CodeFirst
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Subject { get; set; }
        public ICollection<TeacherPupil> TeacherPupils { get; set; }
    }
}
