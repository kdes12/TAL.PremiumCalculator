using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TAL.PremiumCalculator.Business.Mappers
{
    public class PremiumManager : IPremiumManager
    {
        private readonly IOccupationRepository _occupationRepository;

        public PremiumManager(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<PremiumResponse> GetPremiumAsync(Guid occupationId, decimal sumInsured, DateTime dateOfBirth)
        {
            Occupation? occupation = await _occupationRepository.GetOccupationAsync(occupationId);
            if (occupation != null)
            {
                // calculate age
                var age = CalculateAge(dateOfBirth, DateTime.UtcNow);

                return new PremiumResponse
                {
                    // Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12
                    DeathPremium = sumInsured * (decimal)occupation.OccupationRating.Factor * age / 1000 * 12,

                    // TPD Premium Monthly = (Sum Insured* Occupation Rating Factor *Age) / 1234
                    TPDPremiumMonthly = sumInsured * (decimal)occupation.OccupationRating.Factor * age / 1234,
                };
            }

            throw new InvalidOperationException("Unknown occupation.");
        }

        /// <summary>
        /// Calculate age from date of birth (assumed to be in UTC)
        /// Taken from https://stackoverflow.com/a/1595311
        /// </summary>
        /// <param name="dateOfBirth">Date of birth</param>
        /// <param name="utcNow">Current time in UTC</param>
        /// <returns></returns>
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
