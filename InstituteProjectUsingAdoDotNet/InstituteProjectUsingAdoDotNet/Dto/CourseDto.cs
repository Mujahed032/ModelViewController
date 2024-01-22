namespace InstituteProjectUsingAdoDotNet.Dto
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public int CourseFee { get; set; }
        public string Prerequisite { get; set; }
    }
}
