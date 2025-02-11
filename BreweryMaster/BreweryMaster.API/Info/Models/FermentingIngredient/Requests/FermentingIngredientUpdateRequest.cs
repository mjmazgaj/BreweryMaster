using BreweryMaster.API.SharedModule.Validators;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUpdateRequest : FermentingIngredientRequest
    {
        [MinIntValidation]
        public int Id { get; set; }
    }
}
