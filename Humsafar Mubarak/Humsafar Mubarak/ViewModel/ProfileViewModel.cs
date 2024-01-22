using Humsafar_Mubarak.Data.Enum;
using Humsafar_Mubarak.Models;

namespace Humsafar_Mubarak.ViewModel
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string PhotoTag { get; set; }
        public PersonDetails? Person { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public string? BodyType { get; set; }
        public string? Complexion { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? Diet { get; set; }
        public string? Personality { get; set; }
        public Religion? Religion { get; set; }
    }
}
