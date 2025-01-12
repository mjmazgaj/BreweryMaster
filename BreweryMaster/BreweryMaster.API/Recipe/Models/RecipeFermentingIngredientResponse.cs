using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class RecipeFermentingIngredientResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public required string Name { get; set; }
        public float? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public float Quantity { get; set; }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
