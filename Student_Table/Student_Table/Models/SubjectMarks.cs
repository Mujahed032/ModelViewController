using System.ComponentModel.DataAnnotations;

namespace Student_Table.Models
{
    public class SubjectMarks
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public decimal Marks { get; set; }
    }
}
