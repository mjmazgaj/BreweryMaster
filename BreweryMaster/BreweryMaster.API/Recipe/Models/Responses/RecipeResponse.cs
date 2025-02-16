namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public decimal? ABVScale { get; set; }
        public decimal? SRMScale { get; set; }
        public string? TypeName { get; set; }
        public string? StyleName { get; set; }
    }
}
