using BreweryMaster.API.SharedModule.Validators;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientReserveRequest : FermentingIngredientQuantityRequest
    {
        [MinIntValidation(isNullAllowed: true)]
        public int? OrderId { get; set; }
    }
}
