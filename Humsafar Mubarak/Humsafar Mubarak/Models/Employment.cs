using Humsafar_Mubarak.Data.Enum;

namespace Humsafar_Mubarak.Models
{
    public class Employment
    {
        public int Id { get; set; }
        public string? CompanyOrBusinessName { get; set; }
        public string? Designation { get; set; }
        public EmploymentType EmploymentType { get; set; }
    }
}
