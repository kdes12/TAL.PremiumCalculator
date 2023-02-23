using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data.Abstractions
{
    /// <summary>
    /// Configuration repository interface
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Get configuration (always returns first record)
        /// </summary>
        /// <returns>First configuration record, or NULL of no records are available</returns>
        Task<Configuration?> GetAsync();
    }
}