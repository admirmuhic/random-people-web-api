using Microsoft.EntityFrameworkCore;
using RandomPeopleWebAPI.Models;
using RandomPeopleWebAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomPeopleWebAPI.Services
{
    public class PersonAccessorService : IPersonAccessorService
    {
        private readonly RandomPeopleDbContext _context;

        public PersonAccessorService(RandomPeopleDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonViewModel>> GetAllPeopleAsync()
        {
            return await _context.People.Select(o => new PersonViewModel
            {
                Id = o.PersonId,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Street = o.Address.Street,
                ZipCode = o.Address.ZipCode,
                City = o.Address.City,
                IsActive = o.IsActive
            }).ToListAsync();
        }

        public async Task<List<PersonViewModel>> SearchAsync(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return await _context.People.Select(o => new PersonViewModel
                {
                    Id = o.PersonId,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Street = o.Address.Street,
                    ZipCode = o.Address.ZipCode,
                    City = o.Address.City,
                    IsActive = o.IsActive
                }).Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm)).ToListAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
