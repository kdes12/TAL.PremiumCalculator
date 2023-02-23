using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TAL.PremiumCalculator.Business.Objects
{
    /// <summary>
    /// Occupation response business object
    /// </summary>
    public class OccupationResponse
    {
        /// <summary>
        /// Id of occupation
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of occupation
        /// </summary>
        public string Name { get; set; } = default!;
    }
}