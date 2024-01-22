using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_Making.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AboutMe { get; set; }

        public User User { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

      
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Interest> Interests { get; set; }
    }
}
