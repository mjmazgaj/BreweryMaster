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
                Percentage = 62.5f,
                Extraction = 82,
                EBC = 4,
                TypeId = 1,
                Info = "Viking Pilsner malt test info"
            },
            new FermentingIngredient
            {
                Id = 2,
                Name = "Strzegom Monachijski typ II",
                Percentage = 20.8f,
                Extraction = 79,
                EBC = 22,
                TypeId = 1,
                Info = "Strzegom Monachijski typ II test info"
            },
            new FermentingIngredient
            {
                Id = 3,
                Name = "Strzegom Karmel 150",
                Percentage = 10.4f,
                Extraction = 75,
                EBC = 150,
                TypeId = 1,
                Info = "Strzegom Karmel 150 test info"
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
                ExpectedDate = DateTime.Now.AddDays(3),
                OrderedDate = DateTime.Now.AddDays(-3),
                OrderedQuantity = 10,
                Info = "Fermenting Ingredient Ordered Info 1"
            },
            new()
            {
                Id = 2,
                FermentingIngredientUnitId = 1,
                ExpectedDate = DateTime.Now.AddDays(1),
                OrderedDate = DateTime.Now.AddDays(-2),
                OrderedQuantity = 3,
                Info = "Fermenting Ingredient Ordered Info 2"
            },
            new()
            {
                Id = 3,
                FermentingIngredientUnitId = 2,
                ExpectedDate = DateTime.Now.AddDays(2),
                OrderedDate = DateTime.Now.AddDays(-4),
                OrderedQuantity = 33,
                Info = "Fermenting Ingredient Ordered Info 1"
            }
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
                UnitId=1
            },
            new()
            {
                Id=2,
                FermentingIngredientId=1,
                UnitId=2
            },
            new()
            {
                Id=3,
                FermentingIngredientId=1,
                UnitId=3
            },
            new()
            {
                Id=4,
                FermentingIngredientId=2,
                UnitId=1
            },
            new()
            {
                Id=5,
                FermentingIngredientId=2,
                UnitId=2
            }
        };
    }
}
