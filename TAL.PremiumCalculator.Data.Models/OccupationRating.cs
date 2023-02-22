using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    public class OccupationRating
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)] 
        public string Name { get; set; } = default!;

        [Required]
        public double Factor { get; set; }
    }
}
