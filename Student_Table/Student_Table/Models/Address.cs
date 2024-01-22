using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Student_Table.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int CityId { get; set; }
        [Required]
        public City City { get; set; }

        [Required]
        public int StateId { get; set; }
        [Required]
        public State State { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Postal code should be 6 digits.")]
        public string PostalCode { get; set; }
    }
}
