namespace InstituteProjectUsingAdoDotNet.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public char Gender { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string JoinDate { get; set; }

        public ICollection<StudentBatch> StudentBatches { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
