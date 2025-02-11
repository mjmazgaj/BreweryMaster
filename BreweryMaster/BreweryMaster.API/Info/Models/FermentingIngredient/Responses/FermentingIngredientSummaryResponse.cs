using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientSummaryResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public required string Name { get; set; }
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public decimal StoredQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal TotalQuantity { get { return StoredQuantity - ReservedQuantity + OrderedQuantity; } }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
