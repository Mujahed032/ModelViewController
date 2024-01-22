using System.ComponentModel.DataAnnotations;

namespace InstituteWebApI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseCode { get; set; }
        public string? CoursName { get; set; }
        public int CourseDuration { get; set; }
        public int CourseFee { get; set; }
        public string? Prerequisite { get; set; }
    }
}
