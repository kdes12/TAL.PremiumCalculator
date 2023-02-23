using Moq;
using TAL.PremiumCalculator.Business.Mappers;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business.Tests
{
    /// <summary>
    /// Occupation manager tests
    /// </summary>
    public class OccupationManagerTests
    {
        private readonly Mock<IOccupationRepository> _repoMock;
        private readonly List<OccupationRating> _occupationRatings;
        private readonly List<Occupation> _occupations;

        /// <summary>
        /// Construct test and prep fake data
        /// </summary>
        public OccupationManagerTests()
        {
            _occupationRatings = new List<OccupationRating>()
            {
                new OccupationRating { Id = Guid.NewGuid(), Name = "Low Rating", Factor = 1, },
                new OccupationRating { Id = Guid.NewGuid(), Name = "High Rating", Factor = 2, }
            };

            _occupations = new List<Occupation>()
            {
                new Occupation
                {
                    Id = Guid.NewGuid(),
                    Name = "Test 1",
                    OccupationRatingId = _occupationRatings[0].Id,
                    OccupationRating = _occupationRatings[0]
                },
                new Occupation
                {
                    Id = Guid.NewGuid(),
                    Name = "Test 2",
                    OccupationRatingId = _occupationRatings[1].Id,
                    OccupationRating = _occupationRatings[1]
                }
            };

            _repoMock = new Mock<IOccupationRepository>();
            _repoMock.Setup(r => r.GetOccupationsAsync()).ReturnsAsync(_occupations);
            _repoMock.Setup(r => r.GetOccupationAsync(_occupations[0].Id)).ReturnsAsync(_occupations[0]);
        }

        [Fact]
        public void GetOccupations_Success()
        {
            // ARRANGE
            var occupationManager = new OccupationManager(_repoMock.Object, new OccupationMapper());

            // ACT
            var result = occupationManager.GetOccupationsAsync().Result;

            // ASSERT
            Assert.NotEmpty(result);
            Assert.Equal(result[0].Id, _occupations[0].Id);
        }

        [Fact]
        public void GetOccupationRatingFactor_Success()
        {
            // ARRANGE
            var occupationManager = new OccupationManager(_repoMock.Object, new OccupationMapper());

            // ACT
            var result = occupationManager.GetOccupationRatingFactorAsync(_occupations[0].Id).Result;

            // ASSERT
            Assert.Equal(result, _occupationRatings[0].Factor);
        }

        [Fact]
        public async Task GetOccupationRatingFactor_Exception()
        {
            // ARRANGE
            var occupationManager = new OccupationManager(_repoMock.Object, new OccupationMapper());

            // ACT / ASSERT
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => occupationManager.GetOccupationRatingFactorAsync(Guid.NewGuid()));
        }
    }
}