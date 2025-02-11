namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrderRequest : FermentingIngredientQuantityRequest
    {
        public DateTime? ExpectedDate { get; set; }
    }
}
