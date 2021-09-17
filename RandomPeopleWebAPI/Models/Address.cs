using System.Collections.Generic;

#nullable disable

namespace RandomPeopleWebAPI.Models
{
    public partial class Address
    {
        public Address()
        {
            People = new HashSet<Person>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
