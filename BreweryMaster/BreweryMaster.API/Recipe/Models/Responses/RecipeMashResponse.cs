namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeMashResponse
    {
        public int? MashEfficiency { get; set; }
        public decimal? WaterToGrainRatio { get; set; }
        public decimal? MashWaterVolume { get; set; }
        public decimal? TotalMashVolume { get; set; }
    }
}
