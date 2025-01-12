namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public float? BLGScale { get; set; }
        public int? IBUScale { get; set; }
        public float? ABVScale { get; set; }
        public float? SRMScale { get; set; }
        public string? TypeName { get; set; }
        public string? StyleName { get; set; }
    }
}
