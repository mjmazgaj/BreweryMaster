namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientOrdered
    {
        public int Id { get; set; }
        public int FermentingIngredientUnitId { get; set; }
        public required FermentingIngredientUnit FermentingIngredientUnit { get; set; }
        public float OrderedQuantity { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public bool IsRemoved { get; set; } = false;
        public string? Info { get; set; }
    }
}
