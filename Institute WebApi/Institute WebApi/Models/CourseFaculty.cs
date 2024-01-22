namespace Institute_WebApi.Models
{
    public class CourseFaculty
    {
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public char Grade { get; set; }

        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
    }

}
