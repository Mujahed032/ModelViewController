using System.ComponentModel.DataAnnotations;

namespace Testing_Using_AI.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Name { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
