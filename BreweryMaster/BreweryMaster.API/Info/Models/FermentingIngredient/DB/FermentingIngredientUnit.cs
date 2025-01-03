using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUnit
    {
        public int Id { get; set; }
        [ForeignKey("FermentingIngredient")]
        public int FermentingIngredientId { get; set; }
        public required FermentingIngredient FermentingIngredient { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public required Shared.Models.UnitEntity Unit { get; set; }
        public bool IsRemoved { get; set; }
    }
}
