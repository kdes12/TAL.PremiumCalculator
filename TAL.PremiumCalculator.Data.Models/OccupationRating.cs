using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    public class OccupationRating
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public double Factor { get; set; }
    }
}
