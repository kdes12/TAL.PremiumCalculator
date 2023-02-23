using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
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
        private readonly IConfigurationManager _configurationManager;

        /// <summary>
        /// Constructs Premium controller
        /// </summary>
        /// <param name="logger">Logger for errors</param>
        /// <param name="premiumManager">Business layer for premium calculations</param>
        /// <param name="occupationManager">Business layer for occupation manager</param>
        /// <param name="configurationManager">Business layer for configuration manager</param>
        public PremiumController(
            ILogger<PremiumController> logger,
            IPremiumManager premiumManager,
            IOccupationManager occupationManager,
            IConfigurationManager configurationManager)
        {
            _logger = logger;
            _premiumManager = premiumManager;
            _occupationManager = occupationManager;
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Return maximum age currently configured in the system
        /// </summary>
        /// <returns>Maximum age</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(List<ProblemDetails>), 400)]
        public async Task<IActionResult> GetMaximumAgeAsync()
        {
            try
            {
                // get maximum age
                int maximumAge = await _configurationManager.GetMaximumAge();

                // return result
                return Ok(maximumAge);
            }
            catch (Exception ex)
            {
                string message = Constants.RETRIEVE_ERROR_MESSAGE;
                string type = "Maximum Age";
                _logger.LogError(ex, message, type);
                return BadRequest(string.Format(message, type));
            }
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
        public async Task<IActionResult> CalculatePremiumAsync([FromQuery] PremiumQuery query)
        {
            try
            {
                // get rating factor
                double ratingFactor = await _occupationManager.GetOccupationRatingFactorAsync(query.OccupationId);

                // get maximum age
                int maximumAge = await _configurationManager.GetMaximumAge();

                // calculate premium
                PremiumResponse premium = _premiumManager.CalculatePremium(ratingFactor, query.SumInsured, query.DateOfBirth, maximumAge);
                
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
