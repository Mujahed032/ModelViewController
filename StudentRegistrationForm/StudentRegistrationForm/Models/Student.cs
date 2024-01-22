using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace StudentRegistrationForm.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Father's Name is required.")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Mother's Name is required.")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number should be 10 digits.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Marital Status is required.")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Religion is required.")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Caste is required.")]
        public string Caste { get; set; }

        [Required(ErrorMessage = "Reservation is required.")]
        public string Reservation { get; set; }

        [Required(ErrorMessage = "Group to Study is required.")]
        public string GroupToStudy { get; set; }

        [Required(ErrorMessage = "Qualifying Examination is required.")]
        public string QualifyingExamination { get; set; }

        [Required(ErrorMessage = "Board is required.")]
        public string Board { get; set; }

        [Required(ErrorMessage = "Hall Ticket Number is required.")]
        public string HallTicketNo { get; set; }

        [Required(ErrorMessage = "Month and Year of Passing is required.")]
        public string MonthYearOfPassing { get; set; }

        [Required(ErrorMessage = "Total Marks is required.")]
        public decimal TotalMarks { get; set; }

        [Required(ErrorMessage = "Average Marks is required.")]
        public decimal AverageMarks { get; set; }

        [Required(ErrorMessage = "Preferred College Name is required.")]
        public string PreferredCollegeName { get; set; }

        [Required(ErrorMessage = "First Language is required.")]
        public string FirstLanguage { get; set; }

        [Required(ErrorMessage = "Second Language is required.")]
        public string SecondLanguage { get; set; }

        // Foreign key properties
        public int CurrentAddressID { get; set; }
        public int PermanentAddressID { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        // Navigation properties
        [ForeignKey("CurrentAddressID")]
        public Address CurrentAddress { get; set; }
        [ForeignKey("PermanentAddressID")]
        public Address PermanentAddress { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }


}
