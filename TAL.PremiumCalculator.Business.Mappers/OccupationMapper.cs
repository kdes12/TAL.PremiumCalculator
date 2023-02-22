using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Mappers
{
    public class OccupationMapper : IMapper<Occupation, OccupationResponse>
    {
        public OccupationResponse ToResponse(Occupation entity)
        {
            return new OccupationResponse
            {
               Id = entity.Id,
               Name = entity.Name,
            };
        }
    }
}