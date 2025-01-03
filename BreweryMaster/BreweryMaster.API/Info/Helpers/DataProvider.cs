using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Info.Helpers
{
    public static class DataProvider
    {
        public static IEnumerable<FermentingIngredientReserved> GetReserved(IEnumerable<FermentingIngredientUnitResponse> ingredients)
        {
            return ingredients.Select(x => new List<FermentingIngredientReserved>() {
                new ()
            {
                Id = 1,
                FermentingIngredientUnitId = x.FermentingIngredient.Id,
                ReservedQuantity = 25.5f + x.FermentingIngredient.Id,
                OrderId = 5001,
                UserId = 1001,
                ReservationDate = DateTime.UtcNow,
                IsRemoved = false,
                Info = "First reservation"
            },
            new ()
            {
                Id = 2,
                FermentingIngredientUnitId = x.FermentingIngredient.Id,
                    ReservedQuantity = 15.0f,
                    OrderId = 5002,
                    UserId = 1002,
                    ReservationDate = DateTime.UtcNow.AddDays(-1),
                    IsRemoved = false,
                    Info = "Second reservation"
                },
                new ()
                {
                    Id = 3,
                    FermentingIngredientUnitId = x.FermentingIngredient.Id,
                    ReservedQuantity = 50.0f,
                    OrderId = 5003,
                    UserId = 1003,
                    ReservationDate = DateTime.UtcNow.AddDays(-2),
                    IsRemoved = true,
                    Info = "Third reservation (removed)"
                }}).SelectMany(x => x);
        }

        public static IEnumerable<FermentingIngredientStored> GetStored(IEnumerable<FermentingIngredientUnitResponse> ingredients)
        {

            return ingredients.Select(x => new List<FermentingIngredientStored>
            {
                new ()
                {
                    Id = 1,
                    FermentingIngredientUnitId = x.FermentingIngredient.Id,
                    StoredQuantity = 11.0f + x.FermentingIngredient.Id,
                    IsRemoved = false,
                    Info = "First stored"
                },
                new ()
                {
                    Id = 2,
                    FermentingIngredientUnitId = x.FermentingIngredient.Id,
                    StoredQuantity = 33.0f + x.FermentingIngredient.Id,
                    IsRemoved = false,
                    Info = "Second stored"
                },
                new ()
                {
                    Id = 3,
                    FermentingIngredientUnitId = x.FermentingIngredient.Id,
                    StoredQuantity = 22.0f + x.FermentingIngredient.Id,
                    IsRemoved = true,
                    Info = "Third stored"
                }
            }).SelectMany(x => x);
        }
    }
}
