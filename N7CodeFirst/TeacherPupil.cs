namespace N7CodeFirst
{
    public class TeacherPupil
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }
    }
}
