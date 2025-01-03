using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientSummaryResponse
    {
        public int Id { get; set; }
        public FermentingIngredient FermentingIngredient { get; set; }
        public UnitEntity Unit { get; set; }
        public string TypeName { get; set; }
        public float StoredQuantity { get; set; }
        public float ReservedQuantity { get; set; }
        public float OrderedQuantity { get; set; }
        public float TotalQuantity { get { return StoredQuantity + ReservedQuantity + OrderedQuantity; } }
    }
}
