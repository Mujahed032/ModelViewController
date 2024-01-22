using Humsafar_Mubarak.Data.Enum;

namespace Humsafar_Mubarak.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? ZipPostalCode { get; set; }
        public HouseType HouseType { get; set; }
    }
}
