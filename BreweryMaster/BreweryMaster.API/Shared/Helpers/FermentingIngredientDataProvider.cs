using BreweryMaster.API.Info.Models;
using Microsoft.Identity.Client;

public static class FermentingIngredientDataProvider
{
    public static IEnumerable<FermentingIngredient> GetFermentingIngredient()
    {
        return new List<FermentingIngredient>
        {
            new FermentingIngredient
            {
                Id = 1,
                Name = "Viking Pilsner malt",
                Percentage = 62.5m,
                Extraction = 82,
                EBC = 4,
                TypeId = 1,
                Info = "Viking Pilsner malt test info",
                Type = null!
            },
            new FermentingIngredient
            {
                Id = 2,
                Name = "Strzegom Monachijski typ II",
                Percentage = 20.8m,
                Extraction = 79,
                EBC = 22,
                TypeId = 1,
                Info = "Strzegom Monachijski typ II test info",
                Type = null!
            },
            new FermentingIngredient
            {
                Id = 3,
                Name = "Strzegom Karmel 150",
                Percentage = 10.4m,
                Extraction = 75,
                EBC = 150,
                TypeId = 1,
                Info = "Strzegom Karmel 150 test info",
                Type = null!
            }
        };
    }

    public static IEnumerable<FermentingIngredientTypeEntity> GetFermentingIngredientTypeEntity()
    {
        return new List<FermentingIngredientTypeEntity>()
        {
            new()
            {
                Id= 1,
                Name="Ziarno"
            },
            new()
            {
                Id= 2,
                Name="Owoce"
            },
        };
    }

    public static IEnumerable<FermentingIngredientOrdered> GetFermentingIngredientOrdered()
    {
        return new List<FermentingIngredientOrdered>()
        {
            new()
            {
                Id = 1,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(3),
                OrderedDate = DateTime.Now.AddDays(-3),
                OrderedQuantity = 10,
                Info = "Fermenting Ingredient Ordered Info 1"
            },
            new()
            {
                Id = 2,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(1),
                OrderedDate = DateTime.Now.AddDays(-2),
                OrderedQuantity = 3,
                Info = "Fermenting Ingredient Ordered Info 2"
            },
            new()
            {
                Id = 3,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(2),
                OrderedDate = DateTime.Now.AddDays(-4),
                OrderedQuantity = 33,
                Info = "Fermenting Ingredient Ordered Info 1"
            }
        };
    }

    public static IEnumerable<FermentingIngredientReserved> GetFermentingIngredientReserved()
    {
        return new List<FermentingIngredientReserved>()
        {
            new()
            {
                Id = 4,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                ReservedQuantity = 4,
                ReservationDate = DateTime.Now.AddDays(-2),
                Info = "Fermenting Ingredient Reserved Info 1"
            },
            new()
            {
                Id = 5,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                ReservedQuantity = 7,
                ReservationDate = DateTime.Now.AddDays(-1),
                Info = "Fermenting Ingredient Reserved Info 1"
            },
            new()
            {
                Id = 6,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                ReservedQuantity = 10,
                ReservationDate = DateTime.Now.AddDays(-3),
                Info = "Fermenting Ingredient Reserved Info 1"
            },
        };
    }

    public static IEnumerable<FermentingIngredientStored> GetFermentingIngredientStored()
    {
        return new List<FermentingIngredientStored>()
        {
            new()
            {
                Id = 7,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                StoredQuantity = 200,
                Info = "Fermenting Ingredient Stored Info 1"
            },
            new()
            {
                Id = 8,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                StoredQuantity = 230,
                Info = "Fermenting Ingredient Stored Info 1"
            },
            new()
            {
                Id = 9,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                StoredQuantity = 300,
                Info = "Fermenting Ingredient Stored Info 1"
            },
        };
    }

    public static IEnumerable<FermentingIngredientUnit> GetFermentingIngredientUnit()
    {
        return new List<FermentingIngredientUnit>
        {
            new()
            {
                Id=1,
                FermentingIngredientId=1,
                UnitId=1,
                FermentingIngredient = null!,
                Unit = null!
            },
            new()
            {
                Id=2,
                FermentingIngredientId=1,
                UnitId=2,
                FermentingIngredient = null!,
                Unit = null!
            },
            new()
            {
                Id=3,
                FermentingIngredientId=1,
                UnitId=3,
                FermentingIngredient = null!,
                Unit = null!
            },
            new()
            {
                Id=4,
                FermentingIngredientId=2,
                UnitId=1,
                FermentingIngredient = null!,
                Unit = null!
            },
            new()
            {
                Id=5,
                FermentingIngredientId=2,
                UnitId=2,
                FermentingIngredient = null!,
                Unit = null!
            }
        };
    }
}
