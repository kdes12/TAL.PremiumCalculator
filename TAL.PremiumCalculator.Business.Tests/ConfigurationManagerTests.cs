using Moq;
using TAL.PremiumCalculator.Business.Mappers;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Tests
{
    /// <summary>
    /// Configuration manager tests
    /// </summary>
    public class ConfigurationManagerTests
    {
        [Fact]
        public void GetConfigurations_Success()
        {
            // ARRANGE
            var configuration = new Configuration
            {
                MaximumAge = 70,
            };

            var repoMock = new Mock<IConfigurationRepository>();
            repoMock.Setup(r => r.GetAsync()).ReturnsAsync(configuration);
            var occupationManager = new ConfigurationManager(repoMock.Object);

            // ACT
            var result = occupationManager.GetMaximumAge().Result;

            // ASSERT
            Assert.Equal(result, configuration.MaximumAge);
        }

        [Fact]
        public async Task GetConfigurationRatingFactor_Exception()
        {
            // ARRANGE
            var emptyRepoMock = new Mock<IConfigurationRepository>();
            var occupationManager = new ConfigurationManager(emptyRepoMock.Object);

            // ACT / ASSERT
            await Assert.ThrowsAsync<InvalidOperationException>(occupationManager.GetMaximumAge);
        }
    }
}