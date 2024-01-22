using Student_Table.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace Student_Table.Models
{
    public class Student
    {
       
            public int Id { get; set; }

            [Required]
            public string StudentName { get; set; }

            [Required]
            public string FatherName { get; set; }

            [Required]
            public string MotherName { get; set; }

            [Required]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number should be 10 digits.")]
            public string MobileNumber { get; set; }

            [Required]
            public Gender Gender { get; set; }

            [Required]
            public MaritalStatus MaritalStatus { get; set; }

            [ForeignKey("CurrentAddress")]
            public int CurrentAddressId { get; set; }
            public Address CurrentAddress { get; set; }

             [ForeignKey("PermanentAddress")]
             public int? PermanentAddressId { get; set; }
            public Address PermanentAddress { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime DateOfBirth { get; set; }


            [ForeignKey("Nationality")]
            public int NationalityId { get; set; }
            public Country Nationality { get; set; }

            [Required]
            public string Religion { get; set; }

            [Required]
            public string Caste { get; set; }

            [Required]
            public ReservationCategory ReservationCategory { get; set; }

            [Required]
            public string GroupToStudy { get; set; }

            [Required]
            public QualifyingExamination QualifyingExamination { get; set; }

            [Required]
            public string Board { get; set; }

            [Required]
            public string HallTicketNumber { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
            public DateTime MonthYearOfPassing { get; set; }

            public List<SubjectMarks> MarksInEachSubject { get; set; }

            public decimal TotalMarks { get; set; }

            public decimal AverageMarks { get; set; }

            [Required]
            public string PreferredCollege { get; set; }

            [Required]
            public string SecondLanguage { get; set; }

        }
}
