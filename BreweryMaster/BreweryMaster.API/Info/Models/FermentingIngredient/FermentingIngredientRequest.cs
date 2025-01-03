using BreweryMaster.API.Info.Enums;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientRequest
    {
        public FermentingIngredientType Type { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }
        public int Extraction { get; set; }
        public int EBC { get; set; }
        public string Info { get; set; }
    }
}
