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
        private readonly IOccupationRepository _occupationRepository;

        /// <summary>
        /// Construct premium manager
        /// </summary>
        /// <param name="occupationRepository">Occupation repo, for data retrieval</param>
        public PremiumManager(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        /// <summary>
        /// Calculate premium based on given parameters
        /// </summary>
        /// <param name="occupationId">Id of the occupation of the member</param>
        /// <param name="sumInsured">Sum insured for the member</param>
        /// <param name="dateOfBirth">Date of birth of the member</param>
        /// <returns>Premium calculation including Death Premium and TPD Premium Monthly</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<PremiumResponse> GetPremiumAsync(Guid occupationId, decimal sumInsured, DateTime dateOfBirth)
        {
            Occupation? occupation = await _occupationRepository.GetOccupationAsync(occupationId);
            if (occupation != null)
            {
                // calculate age
                var age = CalculateAge(dateOfBirth, DateTime.UtcNow);

                // calculate and return premium
                return new PremiumResponse
                {
                    // Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12
                    DeathPremium = sumInsured * (decimal)occupation.OccupationRating.Factor * age / 1000 * 12,

                    // TPD Premium Monthly = (Sum Insured* Occupation Rating Factor *Age) / 1234
                    TPDPremiumMonthly = sumInsured * (decimal)occupation.OccupationRating.Factor * age / 1234,
                };
            }

            // invalid occupation id was provided, throw
            throw new InvalidOperationException("Unknown occupation.");
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
