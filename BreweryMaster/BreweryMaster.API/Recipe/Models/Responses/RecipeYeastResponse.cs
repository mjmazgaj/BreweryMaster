namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeYeastResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TypeId { get; set; }
        public required string TypeName { get; set; }
        public int FormId { get; set; }
        public required string FormName { get; set; }
        public string? Producer { get; set; }
        public decimal Quantity { get; set; }
        public required string Unit { get; set; }
        public string? Info { get; set; }
    }
}
