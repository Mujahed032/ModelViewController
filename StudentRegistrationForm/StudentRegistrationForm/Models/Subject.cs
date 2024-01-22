namespace StudentRegistrationForm.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public decimal Marks { get; set; }

        // Foreign key property
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
