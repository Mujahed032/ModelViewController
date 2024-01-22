using System.ComponentModel.DataAnnotations;

namespace Employees_Mujahed.Models
{
    public class AddMujahed
    {
        
       
        [Required(ErrorMessage ="This field is Requried")]
      
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        public long Salary { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "This field is Requried")]
        public string Designation { get; set; }


    }
    
}
