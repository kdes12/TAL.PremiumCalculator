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
    public class PremiumCalculatorContext : DbContext, IPremiumCalculatorContext
    {
        public DbSet<Occupation> Occupations { get; set;}
        public DbSet<OccupationRating> OccupationRatings { get; set;}

        public PremiumCalculatorContext(DbContextOptions<PremiumCalculatorContext> dbContextOptions)
            : base (dbContextOptions)
        {
        }
    }
}
