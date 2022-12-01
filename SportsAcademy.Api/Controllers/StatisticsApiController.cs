using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Statistics;

namespace SportsAcademy.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService service;

        public StatisticsApiController(IStatisticsService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Gets statistics about number of bought memberships
        /// </summary>
        /// <returns>Total houses memberships</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatistics()
        {
            var model = await service.Total();

            return Ok(model);
        }
    }
}
