using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data
{
    /// <summary>
    /// Repository for occupation records
    /// </summary>
    public class OccupationRepository : IOccupationRepository
    {
        private readonly PremiumCalculatorContext _context;

        /// <summary>
        /// Construct occupation repo
        /// </summary>
        /// <param name="context">Db context</param>
        public OccupationRepository(PremiumCalculatorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get occupation based on given Id
        /// </summary>
        /// <param name="occupationId">The Id of the occupation to retrieve</param>
        /// <returns>Matching occupation or null if the Id is invalid</returns>
        public async Task<Occupation?> GetOccupationAsync(Guid occupationId)
        {
            // get first matching result, including OccupationRating
            return await _context.Occupations
                .Include(o => o.OccupationRating)
                .FirstOrDefaultAsync(o => o.Id == occupationId);
        }

        /// <summary>
        /// Get all available occupations
        /// </summary>
        /// <returns>List of all available occupations (data models)</returns>
        public async Task<List<Occupation>> GetOccupationsAsync()
        {
            return await _context.Occupations
                .Include(o => o.OccupationRating)
                .ToListAsync();
        }
    }
}
