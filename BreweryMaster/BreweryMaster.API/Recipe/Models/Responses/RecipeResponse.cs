namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public decimal? ABVScale { get; set; }
        public decimal? SRMScale { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int? StyleId { get; set; }
        public string? StyleName { get; set; }
    }
}
