namespace TAL.PremiumCalculator.Business.Abstractions
{
    /// <summary>
    /// Configuration manager interface
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Get configured maximum age
        /// </summary>
        /// <returns>Maxium age</returns>
        Task<int> GetMaximumAge();
    }
}