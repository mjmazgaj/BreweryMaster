using BreweryMaster.API.SharedModule.Validators;

namespace BreweryMaster.API.OrderModules.Models
{
    public class ProspectOrderFilterRequest
    {
        [MinIntValidation(isNullAllowed: true)]
        public int? ClientId { get; set; }

        public DateTime? ExpectedBefore { get; set; }

        public DateTime? ExpectedAfter { get; set; }

        [MinIntValidation(isNullAllowed: true)]
        public int? BeerStyleId { get; set; }
    }
}
