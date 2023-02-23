using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;

namespace TAL.PremiumCalculator.API.Controllers
{
    /// <summary>
    /// Controller to handle Occupation operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OccupationController : ControllerBase
    {
        private readonly ILogger<OccupationController> _logger;
        private readonly IOccupationManager _occupationManager;

        /// <summary>
        /// Construct Occupation controller
        /// </summary>
        /// <param name="logger">Logger for errors</param>
        /// <param name="occupationManager">Business layer for occupation retrieval</param>
        public OccupationController(ILogger<OccupationController> logger, IOccupationManager occupationManager)
        {
            _logger = logger;
            _occupationManager = occupationManager;
        }

        /// <summary>
        /// Retrieves all available Occupations
        /// </summary>
        /// <returns>List of all available Occupations</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<OccupationResponse>), 200)]
        [ProducesResponseType(typeof(List<ProblemDetails>), 400)]
        public async Task<IActionResult> GetOccupationsAsync()
        {
            try
            {
                // get all occupations from occupation manager
                List<OccupationResponse> occupations = await _occupationManager.GetOccupationsAsync();

                // return result
                return Ok(occupations);
            }
            catch (Exception ex)
            {
                string message = Constants.RETRIEVE_ERROR_MESSAGE;
                string type = "Occupations";
                _logger.LogError(ex, message, type);
                return BadRequest(string.Format(message, type));
            }
        }
    }
}
