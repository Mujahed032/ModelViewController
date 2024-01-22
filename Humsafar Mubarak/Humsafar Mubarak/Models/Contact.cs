using System.Numerics;

namespace Humsafar_Mubarak.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        public long? MobileNumbers { get; set; }
        public string? EmailAddress { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
