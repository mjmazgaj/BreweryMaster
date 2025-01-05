namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUnitResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool isUsed { get; set; }
    }
}
