using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Student_Table.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
