using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    public class Occupation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; } = default!;

        public Guid OccupationRatingId { get; set; }

        [ForeignKey(nameof(OccupationRatingId))]
        public virtual OccupationRating OccupationRating {get;set; } = default!;
    }
}
