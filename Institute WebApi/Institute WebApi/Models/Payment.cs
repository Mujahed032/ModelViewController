namespace Institute_WebApi.Models
{
    public class Payment
    {
        public DateTime PaymentDate { get; set; }
        public int StudentId { get; set; }
        public int Amount { get; set; }

        public Student Student { get; set; }
    }

}
