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
    public class OccupationRepository : IOccupationRepository
    {
        private readonly PremiumCalculatorContext _context;

        public OccupationRepository(PremiumCalculatorContext context)
        {
            _context = context;
        }

        public async Task<Occupation?> GetOccupationAsync(Guid occupationId)
        {
            return await _context.Occupations
                .Include(o => o.OccupationRating)
                .FirstOrDefaultAsync(o => o.Id == occupationId);
        }

        public async Task<List<Occupation>> GetOccupationsAsync()
        {
            return await _context.Occupations
                .Include(o => o.OccupationRating)
                .ToListAsync();
        }
    }
}
