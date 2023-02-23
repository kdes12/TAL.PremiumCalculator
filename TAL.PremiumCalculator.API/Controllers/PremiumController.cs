using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.API.Controllers
{
    /// <summary>
    /// Controller to handle Premium operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PremiumController : ControllerBase
    {
        private readonly ILogger<PremiumController> _logger;
        private readonly IPremiumManager _premiumManager;

        /// <summary>
        /// Constructs Premium controller
        /// </summary>
        /// <param name="logger">Logger for errors</param>
        /// <param name="premiumManager">Business layer for premium calculations</param>
        public PremiumController(ILogger<PremiumController> logger, IPremiumManager premiumManager)
        {
            _logger = logger;
            _premiumManager = premiumManager;
        }

        /// <summary>
        /// Calculate premium based on given query paramters
        /// </summary>
        /// <param name="query">Parameters for premium calculation</param>
        /// <returns>Premium calculation, including Death Premium and TPD Premium Monthly</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(PremiumResponse), 200)]
        [ProducesResponseType(typeof(List<ProblemDetails>), 400)]
        public async Task<IActionResult> GetPremium([FromQuery] PremiumQuery query)
        {
            try
            {
                // calculate premium
                PremiumResponse premium = await _premiumManager.GetPremiumAsync(query.OccupationId, query.SumInsured, query.DateOfBirth);
                
                // return result
                return Ok(premium);
            }
            catch (Exception ex)
            {
                string message = Constants.RETRIEVE_ERROR_MESSAGE;
                string type = "Premium";
                _logger.LogError(ex, message, type);
                return BadRequest(string.Format(message, type));
            }
        }
    }
}
