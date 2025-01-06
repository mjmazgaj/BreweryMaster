using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientRequest
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required int TypeId { get; set; }
        public float? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public string? Info { get; set; }
        [Required]
        public required IEnumerable<int> Units { get; set; }
    }
}
