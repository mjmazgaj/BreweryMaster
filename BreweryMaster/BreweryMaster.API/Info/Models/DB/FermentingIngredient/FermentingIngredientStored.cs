namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientStored
    {
        public int Id { get; set; }
        public int FermentingIngredientUnitId { get; set; }
        public required FermentingIngredientUnit FermentingIngredientUnit { get; set; }
        public float StoredQuantity { get; set; }
        public bool IsRemoved { get; set; } = false;
        public string? Info { get; set; }
    }
}
