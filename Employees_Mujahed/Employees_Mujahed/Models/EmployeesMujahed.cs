using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employees_Mujahed.Models
{
    public class EmployeesMujahed
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This field is Requried")]

        [StringLength(10, MinimumLength = 3)]
        public string Name  { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This field is Requried")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail format is not valid")]
        [EmailAddress]
        public string Email  { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This field is Requried")]

        public long Salary { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This field is Requried")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "This field is Requried")]
       
        [RegularExpression("^[A-Za-z-' ]+$", ErrorMessage = " format is not valid")]
        public string Designation { get; set; }

    }
}
