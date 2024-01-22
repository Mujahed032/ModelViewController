namespace Institute_WebApi.Models
{
    public class StudentBatch
    {
        public int BatchId { get; set; }
        public int StudentId { get; set; }

        public Batch Batch { get; set; }
        public Student Student { get; set; }
    }

}
