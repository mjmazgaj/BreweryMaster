using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientSummaryResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public required string Name { get; set; }
        public float? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public float StoredQuantity { get; set; }
        public float ReservedQuantity { get; set; }
        public float OrderedQuantity { get; set; }
        public float TotalQuantity { get { return StoredQuantity + ReservedQuantity + OrderedQuantity; } }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
