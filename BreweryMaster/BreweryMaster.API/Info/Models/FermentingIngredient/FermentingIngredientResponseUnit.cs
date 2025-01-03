using BreweryMaster.API.Info.Enums;
using BreweryMaster.API.Shared.Models;

namespace BreweryMaster.API.Info.Models
{
    public class FermentingIngredientUnitResponse
    {
        public int Id { get; set; }
        public required FermentingIngredient FermentingIngredient { get; set; }
        public required UnitEntity Unit { get; set; }
    }
}
