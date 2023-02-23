using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    /// <summary>
    /// Get Occupations via repository
    /// </summary>
    /// <returns>List of Occupations (business objects)</returns>
    public interface IOccupationManager
    {
        /// <summary>
        /// Retrieve all available occupations
        /// </summary>
        /// <returns>List of all available occupations</returns>
        Task<List<OccupationResponse>> GetOccupationsAsync();
    }
}