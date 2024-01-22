namespace InstituteProjectUsingAdoDotNet.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }

        public ICollection<CourseFaculty> CourseFaculties { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}
