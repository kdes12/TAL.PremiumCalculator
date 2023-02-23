using Moq;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Mappers;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Tests
{
    /// <summary>
    /// Premium manager tests
    /// </summary>
    public class PremiumManagerTests
    {
        [Fact]
        public void GetPremiums_Success()
        {
            // ARRANGE
            var premiumManager = new PremiumManager();

            // ACT
            var result = premiumManager.CalculatePremium(2, 10000, new DateTime(1980, 5, 1), 70);

            // ASSERT
            Assert.Equal(10080, result.DeathPremium);
            Assert.Equal(680.71, double.Round((double)result.TPDPremiumMonthly, 2));
        }

        [Fact]
        public void GetPremiums_Exception()
        {
            // ARRANGE
            var premiumManager = new PremiumManager();

            // ACT / ASSERT
            Assert.Throws<InvalidOperationException>(
                () => premiumManager.CalculatePremium(2, 10000, new DateTime(1980, 5, 1), 25));
        }
    }
}