using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TAL.PremiumCalculator.Business.Objects
{
    public class OccupationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
}