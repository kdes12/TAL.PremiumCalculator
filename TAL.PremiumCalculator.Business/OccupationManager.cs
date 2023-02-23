﻿using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Business
{
    /// <summary>
    /// Business layer for Occupations
    /// </summary>
    public class OccupationManager : IOccupationManager
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IMapper<Occupation, OccupationResponse> _occupationMapper;

        /// <summary>
        /// Construct Occupation manager
        /// </summary>
        /// <param name="occupationRepository">Occupation repo, for data retrieval</param>
        /// <param name="occupationMapper">Occupation mapper, to convert from data models to business objects</param>
        public OccupationManager(IOccupationRepository occupationRepository, IMapper<Occupation, OccupationResponse> occupationMapper)
        {
            _occupationRepository = occupationRepository;
            _occupationMapper = occupationMapper;
        }

        /// <summary>
        /// Get Occupations via repository
        /// </summary>
        /// <returns>List of Occupations (business objects)</returns>
        public async Task<List<OccupationResponse>> GetOccupationsAsync()
        {
            // get occupations
            List<Occupation> occupations = await _occupationRepository.GetOccupationsAsync();

            // map to business objects, return result
            return occupations.Select(_occupationMapper.ToResponse).ToList();
        }
    }
}