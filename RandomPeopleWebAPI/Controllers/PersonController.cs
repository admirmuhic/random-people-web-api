using Microsoft.AspNetCore.Mvc;
using RandomPeopleWebAPI.Cache;
using RandomPeopleWebAPI.Models.ViewModels;
using RandomPeopleWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomPeopleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonAccessorService _personAccessor;

        public PersonController(IPersonAccessorService personAccessor)
        {
            _personAccessor = personAccessor;
        }

        [HttpGet]
        [Cached(600)]
        public Task<List<PersonViewModel>> Get()
        {
            return _personAccessor.GetAllPeopleAsync();
        }

        [HttpGet]
        [Route("search")]
        [Cached(600)]
        public Task<List<PersonViewModel>> Search([FromQuery] string searchTerm)
        {
            return _personAccessor.SearchAsync(searchTerm);
        }
    }
}
