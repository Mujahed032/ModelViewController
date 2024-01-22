namespace Institute_WebApi.Dto
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public char Gender { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
