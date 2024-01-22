using Student_Form.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Form.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(15, MinimumLength =5)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Please enter a valid name.")]
        public string StudentName { get; set; }


        public Gender Gender { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public long PhoneNumber { get; set; }

        [ForeignKey("PermanentAddress")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Address PermanentAddress { get; set; }

        [ForeignKey("CurrentAddress")]
        public Address CurrentAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Hobbies Hobbies { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Course Course { get; set; }


    }
}
