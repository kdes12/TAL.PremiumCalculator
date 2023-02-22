using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PremiumController : ControllerBase
    {
        private readonly ILogger<PremiumController> _logger;
        private readonly IPremiumManager _premiumManager;

        public PremiumController(ILogger<PremiumController> logger, IPremiumManager premiumManager)
        {
            _logger = logger;
            _premiumManager = premiumManager;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(PremiumResponse), 200)]
        [ProducesResponseType(typeof(List<ProblemDetails>), 400)]
        public async Task<IActionResult> GetPremium([FromQuery] PremiumQuery query)
        {
            try
            {
                PremiumResponse premium = await _premiumManager.GetPremiumAsync(query.OccupationId, query.SumInsured, query.Age);
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
