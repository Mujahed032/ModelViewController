using Humsafar_Mubarak.Data.Enum;

namespace Humsafar_Mubarak.Models
{
    public class Education
    {
        public int Id { get; set; }
        public EducationLevel? HighestQualification { get; set; }
        public string? NameOfInstitution { get; set; }
    }
}
