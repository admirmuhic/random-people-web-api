using Microsoft.AspNetCore.Mvc;
using RandomPeopleWebAPI.Cache;
using RandomPeopleWebAPI.Models.ViewModels;
using RandomPeopleWebAPI.Services;
using System.Collections.Generic;

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
        public IEnumerable<PersonViewModel> Get()
        {
            return _personAccessor.GetAllPeople();
        }

        [HttpGet]
        [Route("search")]
        [Cached(600)]
        public IEnumerable<PersonViewModel> Search([FromQuery] string searchTerm)
        {
            return _personAccessor.Search(searchTerm);
        }
    }
}
