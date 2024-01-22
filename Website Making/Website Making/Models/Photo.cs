using System.ComponentModel.DataAnnotations;

namespace Website_Making.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}
