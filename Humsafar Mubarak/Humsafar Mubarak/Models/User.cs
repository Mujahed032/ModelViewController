namespace Humsafar_Mubarak.Models
{
    public class User
    {
        public int Id { get; set; }
       
        public string? Email { get; set; }
        public string? Password { get; set; } = string.Empty;

        public CandidateProfile? Profile { get; set; }
    }
}






