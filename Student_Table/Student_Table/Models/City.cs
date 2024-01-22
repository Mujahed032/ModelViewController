using System.ComponentModel.DataAnnotations;

namespace Student_Table.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
