namespace StudentRegistrationForm.Models
{

    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        public int CountryID { get; set; }

        public Country Country { get; set; }
        public int CityID { get; set; }

        public ICollection<City> Cities { get; set; }

    }
        

    
}
