using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    /// <summary>
    /// Premium manager interface
    /// </summary>
    public interface IPremiumManager
    {
        /// <summary>
        /// Calculate premium based on given parameters
        /// </summary>
        /// <param name="occupationId">Id of the occupation of the member</param>
        /// <param name="sumInsured">Sum insured for the member</param>
        /// <param name="dateOfBirth">Date of birth of the member</param>
        /// <returns>Premium calculation including Death Premium and TPD Premium Monthly</returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<PremiumResponse> GetPremiumAsync(Guid occupationId, decimal sumInsured, DateTime dateOfBirth);
    }
}
