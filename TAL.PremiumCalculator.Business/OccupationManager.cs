using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business
{
    public class OccupationManager : IOccupationManager
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IMapper<Occupation, OccupationResponse> _occupationMapper;

        public OccupationManager(IOccupationRepository occupationRepository, IMapper<Occupation, OccupationResponse> occupationMapper)
        {
            _occupationRepository = occupationRepository;
            _occupationMapper = occupationMapper;
        }

        public async Task<List<OccupationResponse>> GetOccupationsAsync()
        {
            List<Occupation> occupations = await _occupationRepository.GetOccupationsAsync();
            return occupations.Select(_occupationMapper.ToResponse).ToList();
        }
    }
}