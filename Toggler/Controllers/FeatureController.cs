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
    public class FeatureController : Controller
    {
        private readonly FeatureRepository _featureRepository;

        public FeatureController(FeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        [HttpGet()]
        public async Task<IEnumerable<Feature>> Get()
        {
            return await _featureRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Feature feature)
        {
            await _featureRepository.InsertAsync(feature);

            return Ok();
        }
    }
}
