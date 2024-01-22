using Humsafar_Mubarak.Data.Enum;

namespace Humsafar_Mubarak.Models
{
    public class PersonDetails
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public RelationToCandidate? Relation { get; set; }
        public Contact? Contact { get; set; }

        public Education? Education { get; set; }

        public bool Employed { get; set; }
        public Employment? Employment { get; set; }
    }
}
