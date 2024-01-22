using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_Making.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string passwordHash { get; set; }

        public string Email { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}
