using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Objects
{
    /// <summary>
    /// Premium response busines object
    /// </summary>
    public class PremiumResponse
    {
        /// <summary>
        /// Death premium calculated for member
        /// </summary>
        public decimal DeathPremium { get; set; }

        /// <summary>
        /// TPD premium monthly calculated for member
        /// </summary>
        public decimal TPDPremiumMonthly { get; set; }
    }
}
