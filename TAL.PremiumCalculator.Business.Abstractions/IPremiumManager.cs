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
        /// <param name="ratingFactor">Rating factor for the members occupation</param>
        /// <param name="sumInsured">Sum insured for the member</param>
        /// <param name="dateOfBirth">Date of birth of the member</param>
        /// <param name="maximumAge">The maximum age that a premium is valid for</param>
        /// <returns>Premium calculation including Death Premium and TPD Premium Monthly</returns>
        PremiumResponse CalculatePremium(double ratingFactor, decimal sumInsured, DateTime dateOfBirth, int maximumAge);
    }
}
