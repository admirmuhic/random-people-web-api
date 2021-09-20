using RandomPeopleWebAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomPeopleWebAPI.Services
{
    public interface IPersonAccessorService
    {
        Task<List<PersonViewModel>> GetAllPeopleAsync();
        Task<List<PersonViewModel>> SearchAsync(string searchTerm);
    }
}
