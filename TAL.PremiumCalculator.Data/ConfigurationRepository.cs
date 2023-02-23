using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data
{
    /// <summary>
    /// Configuration repository
    /// </summary>
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly PremiumCalculatorContext _context;

        /// <summary>
        /// Construct configuration repo
        /// </summary>
        /// <param name="context">Db context</param>
        public ConfigurationRepository(PremiumCalculatorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get configuration (always returns first record)
        /// </summary>
        /// <returns>First configuration record, or NULL of no records are available</returns>
        public async Task<Configuration?> GetAsync()
        {
            return await _context.Configurations.FirstOrDefaultAsync();
        }
    }
}
