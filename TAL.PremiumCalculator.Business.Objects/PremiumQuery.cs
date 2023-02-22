using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Objects
{
    public class PremiumQuery
    {
        public Guid OccupationId { get; set; }
        public decimal SumInsured { get; set; }
        public uint Age { get; set; }

    }
}
