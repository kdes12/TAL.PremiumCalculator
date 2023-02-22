using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data.Abstractions
{
    public interface IOccupationRepository
    {
        Task<List<Occupation>> GetOccupationsAsync();
    }
}
