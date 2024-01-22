namespace InstituteProjectUsingAdoDotNet.Dto
{
    public class BtachDto
    {
        public int BatchId { get; set; }
        public string BatchCode { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte TimeSlot { get; set; }
    }
}
