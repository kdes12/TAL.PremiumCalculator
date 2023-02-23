using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    /// <summary>
    /// Occupation data model
    /// </summary>
    public class Occupation
    {
        /// <summary>
        /// Id for Occupation records (primary key)
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Occupation name, nvarchar(500) and non-nullable
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Occupation rating identifier, non-nullable FK to OccpationRating table
        /// </summary>
        public Guid OccupationRatingId { get; set; }

        /// <summary>
        /// OccupationRating navigation property
        /// </summary>
        [ForeignKey(nameof(OccupationRatingId))]
        public virtual OccupationRating OccupationRating {get;set; } = default!;
    }
}
