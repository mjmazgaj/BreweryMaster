using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientSummaryResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public decimal StoredQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal TotalQuantity { get { return StoredQuantity - ReservedQuantity; } }
        public string Unit { get; set; } = string.Empty;
        public IEnumerable<int>? Units { get; set; }
        public string? Info { get; set; }
    }
}
