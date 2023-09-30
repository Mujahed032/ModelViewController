using Student_Form.Data;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace Student_Form.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [StringLength(20, MinimumLength =7)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ConfirmPassword { get; set; }
        public long PhoneNumber { get; set; }

        public int AddressId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Address PermanentAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Address CurrentAddress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Hobbies Hobbies { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Course Course { get; set; }
    }
}
