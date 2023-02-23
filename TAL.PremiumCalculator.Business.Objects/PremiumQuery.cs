using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Business.Objects
{
    /// <summary>
    /// Query string definition for Premium calculation
    /// </summary>
    public class PremiumQuery
    {
        /// <summary>
        /// Id of relevant member occupation
        /// </summary>
        [Required]
        public Guid OccupationId { get; set; }

        /// <summary>
        /// Sum insured for member
        /// </summary>
        [Required]
        public decimal SumInsured { get; set; }

        /// <summary>
        /// Date of birth of member
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
