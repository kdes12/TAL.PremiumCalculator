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
        private readonly IOccupationManager _occupationManager;

        /// <summary>
        /// Constructs Premium controller
        /// </summary>
        /// <param name="logger">Logger for errors</param>
        /// <param name="premiumManager">Business layer for premium calculations</param>
        /// <param name="occupationManager">Business layer for occupation manager</param>
        public PremiumController(ILogger<PremiumController> logger, IPremiumManager premiumManager, IOccupationManager occupationManager)
        {
            _logger = logger;
            _premiumManager = premiumManager;
            _occupationManager = occupationManager;
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
                // get ratingFactor
                double ratingFactor = await _occupationManager.GetOccupationRatingFactorAsync(query.OccupationId);

                // calculate premium
                PremiumResponse premium = _premiumManager.CalculatePremiumAsync(ratingFactor, query.SumInsured, query.DateOfBirth);
                
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
