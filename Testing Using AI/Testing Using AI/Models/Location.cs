using System.ComponentModel.DataAnnotations;

namespace Testing_Using_AI.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Profile Profile { get; set; }
    }
}
