namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeYeastResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public int FormId { get; set; }
        public string FormName { get; set; } = string.Empty;
        public string? Producer { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Info { get; set; }
    }
}
