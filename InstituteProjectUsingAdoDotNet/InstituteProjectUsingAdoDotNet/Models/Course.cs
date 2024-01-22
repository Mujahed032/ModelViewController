namespace InstituteProjectUsingAdoDotNet.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public int CourseFee { get; set; }
        public string Prerequisite { get; set; }

        public ICollection<CourseFaculty> CourseFaculties { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}
