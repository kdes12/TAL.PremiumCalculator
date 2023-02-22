using TAL.PremiumCalculator.Business.Objects;

namespace TAL.PremiumCalculator.Business.Abstractions
{
    public interface IPremiumManager
    {
        Task<PremiumResponse> GetPremiumAsync(Guid occupationId, decimal sumInsured, uint age);
    }
}
