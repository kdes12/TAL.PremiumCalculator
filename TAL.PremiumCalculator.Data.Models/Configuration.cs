using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAL.PremiumCalculator.Data.Models
{
    /// <summary>
    /// Configuration table, with administerable config info
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Maximum age config
        /// </summary>
        [Required]
        public int MaximumAge { get; set; }
    }
}
