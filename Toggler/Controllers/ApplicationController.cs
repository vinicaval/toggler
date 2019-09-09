using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toggler.Core.Entity;
using Toggler.Core.Repository;

namespace Toggler.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationController(ApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Application>> Get()
        {
            return await _applicationRepository.GetAsync();
        }
    }
}
