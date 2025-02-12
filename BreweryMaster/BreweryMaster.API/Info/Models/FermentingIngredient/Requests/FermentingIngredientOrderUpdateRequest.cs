namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrderUpdateRequest : FermentingIngredientQuantityUpdateRequest
    {
        public DateTime? ExpectedDate { get; set; }
    }
}