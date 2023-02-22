using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Mappers
{
    public class PremiumManager : IPremiumManager
    {
        private readonly IOccupationRepository _occupationRepository;

        public PremiumManager(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public async Task<PremiumResponse> GetPremiumAsync(Guid occupationId, decimal sumInsured, uint age)
        {
            Occupation? occupation = await _occupationRepository.GetOccupationAsync(occupationId);
            if (occupation != null)
            {
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
    }
}
