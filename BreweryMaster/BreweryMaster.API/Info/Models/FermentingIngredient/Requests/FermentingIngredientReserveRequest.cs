namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientReserveRequest : FermentingIngredientQuantityRequest
    {
        public int? OrderId { get; set; }
    }
}
