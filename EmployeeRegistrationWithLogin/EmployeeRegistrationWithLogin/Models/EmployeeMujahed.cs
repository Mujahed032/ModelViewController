using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeRegistrationWithLogin.Models
{
    public class EmployeeMujahed
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is Requried")]

        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail format is not valid")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is Requried")]

        public long Salary { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "This field is Requried")]

        [RegularExpression("^[A-Za-z-' ]+$", ErrorMessage = " format is not valid")]
        public string Designation { get; set; }
    }
}
