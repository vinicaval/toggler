using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toggler.Core.Entity;
using Toggler.Core.Repository;

namespace Toggler.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly ApplicationRepository _applicationRepository;

        public ApplicationController(ApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet()]
        public async Task<IEnumerable<Application>> Get()
        {
            return await _applicationRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Application application)
        {
            await _applicationRepository.InsertAsync(application);

            return Ok();
        }
    }
}
