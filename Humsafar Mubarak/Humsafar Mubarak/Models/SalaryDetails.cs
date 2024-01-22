using Humsafar_Mubarak.Data.Enum;

namespace Humsafar_Mubarak.Models
{
    public class SalaryDetails
    {
        public int Id { get; set; }
        public string? Currency { get; set; }
        public double SalaryAmount { get; set; }
        public SalaryFrequency SalaryFrequency { get; set; }
    }
}
