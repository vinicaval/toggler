using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _applicationRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Application> GetById(Guid id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Application application)
        {
            await _applicationRepository.InsertAsync(application);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PostToggle([FromQuery] Guid IdApplication, [FromBody]IEnumerable<Feature> features)
        {
            await _applicationRepository.InsertToggleAsync(IdApplication, features);

            return Ok();
        }
    }
}
