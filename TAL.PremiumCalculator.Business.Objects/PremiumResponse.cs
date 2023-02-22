using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Objects
{
    public class PremiumResponse
    {
        public decimal DeathPremium { get; set; }
        public decimal TPDPremiumMonthly { get; set; }
    }
}
