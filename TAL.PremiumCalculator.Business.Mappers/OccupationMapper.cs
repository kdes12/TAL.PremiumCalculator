using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Mappers
{
    /// <summary>
    /// Mapper for Occupation and OccupationResponse
    /// </summary>
    public class OccupationMapper : IMapper<Occupation, OccupationResponse>
    {
        /// <summary>
        /// Map from Occupation to OccupationResponse
        /// </summary>
        /// <param name="entity">Occupation data model</param>
        /// <returns>OccupationResponse business object</returns>
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