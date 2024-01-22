namespace StudentRegistrationForm.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }

     
        public int CountryID { get; set; }

        public Country Country { get; set; }
    }
}
