using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data.Abstractions
{
    /// <summary>
    /// Occupation repo interface
    /// </summary>
    public interface IOccupationRepository
    {

        /// <summary>
        /// Get occupation based on given Id
        /// </summary>
        /// <param name="occupationId">The Id of the occupation to retrieve</param>
        /// <returns>Matching occupation or null if the Id is invalid</returns>
        Task<Occupation?> GetOccupationAsync(Guid occupationId);

        /// <summary>
        /// Get all available occupations
        /// </summary>
        /// <returns>List of all available occupations (data models)</returns>
        Task<List<Occupation>> GetOccupationsAsync();
    }
}
