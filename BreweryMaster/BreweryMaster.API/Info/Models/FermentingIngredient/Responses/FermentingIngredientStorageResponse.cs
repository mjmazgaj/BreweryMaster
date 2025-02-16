namespace BreweryMaster.API.Info.Services
{
    public class FermentingIngredientStorageResponse
    {
        public int Id { get; set; }
        public int FermentingIngredientUnit { get; set; }
        public string? Info { get; set; }
        public decimal StoredQuantity { get; set; }
    }
}