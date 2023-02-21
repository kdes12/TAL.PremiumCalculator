using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Abstractions;

namespace TAL.PremiumCalculator.Data
{
    public class PremiumCalculatorContext : DbContext, IPremiumCalculatorContext
    {
    }
}
