using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    public interface IOccupationManager
    {
        Task<List<OccupationResponse>> GetOccupationsAsync();
    }
}