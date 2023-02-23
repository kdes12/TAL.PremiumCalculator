using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business
{
    /// <summary>
    /// Configuration business layer
    /// </summary>
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfigurationRepository _configurationRepository;

        /// <summary>
        /// Constructs configuration manager
        /// </summary>
        /// <param name="configurationRepository">Configuration repository, for data retrieval</param>
        public ConfigurationManager(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        /// <summary>
        /// Get configured maximum age
        /// </summary>
        /// <returns>Maxium age</returns>
        public async Task<int> GetMaximumAge()
        {
            Configuration? config = await _configurationRepository.GetAsync();
            if (config != null)
            {
                return config.MaximumAge;
            }

            throw new InvalidOperationException("Could not retrieve configuration");
        }
    }
}
