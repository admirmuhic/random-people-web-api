#nullable disable

namespace RandomPeopleWebAPI.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public sbyte IsActive { get; set; }

        public virtual Address Address { get; set; }
    }
}
