using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business
{
    /// <summary>
    /// Business layer for premium calculations
    /// </summary>
    public class PremiumManager : IPremiumManager
    {
        /// <summary>
        /// Calculate premium based on given parameters
        /// </summary>
        /// <param name="ratingFactor">Rating factor for the members occupation</param>
        /// <param name="sumInsured">Sum insured for the member</param>
        /// <param name="dateOfBirth">Date of birth of the member</param>
        /// <param name="maximumAge">The maximum age that a premium is valid for</param>
        /// <returns>Premium calculation including Death Premium and TPD Premium Monthly</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public PremiumResponse CalculatePremium(double ratingFactor, decimal sumInsured, DateTime dateOfBirth, int maximumAge)
        {
            // calculate age
            var age = CalculateAge(dateOfBirth, DateTime.UtcNow);

            // if the member age is too high, throw
            if (age > maximumAge)
            {
                throw new InvalidOperationException("Maximum age is 70.");
            }

            // calculate and return premium
            return new PremiumResponse
            {
                // Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12
                DeathPremium = sumInsured * (decimal)ratingFactor * age / 1000 * 12,

                // TPD Premium Monthly = (Sum Insured* Occupation Rating Factor *Age) / 1234
                TPDPremiumMonthly = sumInsured * (decimal)ratingFactor * age / 1234,
            };
        }

        /// <summary>
        /// Calculate age from date of birth (assumed to be in UTC)
        /// Taken from https://stackoverflow.com/a/1595311
        /// </summary>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <param name="utcNow">Current time in UTC</param>
        /// <returns>Calculated age</returns>
        private int CalculateAge(DateTime dateOfBirth, DateTime utcNow)
        {
            int age = utcNow.Year - dateOfBirth.Year;

            // for leap years we need this
            if (dateOfBirth > utcNow.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
