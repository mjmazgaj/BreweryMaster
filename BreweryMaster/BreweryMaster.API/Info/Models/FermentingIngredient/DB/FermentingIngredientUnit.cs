using System.ComponentModel.DataAnnotations.Schema;
using BreweryMaster.API.Shared.Models.DB;

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
        public required UnitEntity Unit { get; set; }
        public bool IsRemoved { get; set; }
    }
}
