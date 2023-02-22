using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    public class Occupation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OccupationRatingId { get; set; }
        public virtual OccupationRating OccupationRating {get;set;}
    }
}
