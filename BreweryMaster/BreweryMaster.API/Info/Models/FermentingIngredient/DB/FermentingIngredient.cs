namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredient
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TypeId { get; set; }
        public float? Percentage { get; set; }
        public int? Extraction { get; set; }
        public int? EBC { get; set; }
        public bool IsRemoved { get; set; } = false;
        public string? Info { get; set; }
    }
}
