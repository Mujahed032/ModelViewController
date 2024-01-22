namespace InstituteProjectUsingAdoDotNet.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchCode { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte TimeSlot { get; set; }

        public Course Course { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<StudentBatch> StudentBatches { get; set; }
    }
}
