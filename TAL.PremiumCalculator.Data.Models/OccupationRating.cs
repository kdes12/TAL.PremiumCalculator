using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    /// <summary>
    /// Occupation rating data model
    /// </summary>
    public class OccupationRating
    {
        /// <summary>
        /// Id for Occupation rating records (primary key)
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Occupation rating name, nvarchar(100) and non-nullable
        /// </summary>
        [Required]
        [StringLength(100)] 
        public string Name { get; set; } = default!;

        /// <summary>
        /// Factor, float and non-nullable
        /// </summary>
        [Required]
        public double Factor { get; set; }
    }
}
