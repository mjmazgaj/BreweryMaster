namespace BreweryMaster.API.Recipe.Models.Responses
{
    public class RecipeBatchResponse
    {
        public int ExpectedBeerVolume { get; set; }
        public int? BoilTime { get; set; }
        public int? EvaporationRate { get; set; }
        public int WortVolume { get; set; }
        public int? BoilLoss { get; set; }
        public decimal? PreBoilGravity { get; set; }
        public int? FermentationLoss { get; set; }
        public int? DryHopLoss { get; set; }
    }
}
