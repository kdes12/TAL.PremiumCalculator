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
        /// Get occupation rating factor based on given occupation Id
        /// </summary>
        /// <param name="occupationId">Id of the relevant occupation</param>
        /// <returns>Occupation rating factor</returns>
        Task<double> GetOccupationRatingFactorAsync(Guid occupationId);

        /// <summary>
        /// Retrieve all available occupations
        /// </summary>
        /// <returns>List of all available occupations</returns>
        Task<List<OccupationResponse>> GetOccupationsAsync();
    }
}