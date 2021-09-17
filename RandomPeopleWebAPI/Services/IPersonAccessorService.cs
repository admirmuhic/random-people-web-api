using RandomPeopleWebAPI.Models.ViewModels;
using System.Collections.Generic;

namespace RandomPeopleWebAPI.Services
{
    public interface IPersonAccessorService
    {
        IEnumerable<PersonViewModel> GetAllPeople();
        IEnumerable<PersonViewModel> Search(string searchTerm);
    }
}
