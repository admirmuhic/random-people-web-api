using RandomPeopleWebAPI.Models;
using RandomPeopleWebAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RandomPeopleWebAPI.Services
{
    public class PersonAccessorService : IPersonAccessorService
    {
        private readonly RandomPeopleDbContext _context;

        public PersonAccessorService(RandomPeopleDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonViewModel> GetAllPeople()
        {
            return _context.People
                .Join(
                    _context.Addresses,
                    person => person.AddressId,
                    address => address.AddressId,
                    (person, address) => new PersonViewModel()
                    {
                        Id = person.PersonId,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        IsActive = person.IsActive,
                        City = address.City
                    }
                ).ToList();
        }

        public IEnumerable<PersonViewModel> Search(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return _context.People
                .Join(
                    _context.Addresses,
                    person => person.AddressId,
                    address => address.AddressId,
                    (person, address) => new PersonViewModel()
                    {
                        Id = person.PersonId,
                        FirstName = person.FirstName,
                        LastName = person.LastName
                    }
                ).Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm)).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
