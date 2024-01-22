namespace StudentRegistrationForm.Models
{
    public class Country
    {
        public int CountryID { get; set; }

        public string Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}
