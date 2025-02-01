using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models.DB;

public static class RecipeDataProvider
{
    public static IEnumerable<Recipe> GetRecpies()
    {
        return new List<Recipe>
            {
                new Recipe
                {
                    Id = 1,
                    Name = "Ciekawe piwo",
                    BLGScale = 12.5m,
                    IBUScale = 35,
                    ABVScale = 5.2m,
                    SRMScale = 6.0m,
                    TypeId = 1,
                    StyleId = 2,
                    ExpectedBeerVolume = 20,
                    BoilTime = 60,
                    EvaporationRate = 10,
                    WortVolume = 25,
                    BoilLoss = 5,
                    PreBoilGravity = 11.5m,
                    FermentationLoss = 1,
                    DryHopLoss = 1,
                    MashEfficiency = 75,
                    WaterToGrainRatio = 3,
                    MashWaterVolume = 15.0m,
                    TotalMashVolume = 18,
                    CreatedById = "todo",
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Smaczne piwo",
                    BLGScale = 15.0m,
                    IBUScale = 45,
                    ABVScale = 6.0m,
                    SRMScale = 40.0m,
                    TypeId = 1,
                    StyleId = 3,
                    ExpectedBeerVolume = 18,
                    BoilTime = 90,
                    EvaporationRate = 12,
                    WortVolume = 22,
                    BoilLoss = 4,
                    PreBoilGravity = 13.5m,
                    FermentationLoss = 2,
                    DryHopLoss = 0,
                    MashEfficiency = 70,
                    WaterToGrainRatio = 2.5m,
                    MashWaterVolume = 14.0m,
                    TotalMashVolume = 16,
                    CreatedById = "todo",
                },
                new Recipe
                {
                    Id = 3,
                    Name = "Swietne piwo",
                    BLGScale = 14.0m,
                    IBUScale = 60,
                    ABVScale = 6.5m,
                    SRMScale = 8.0m,
                    TypeId = 2,
                    StyleId = 4,
                    ExpectedBeerVolume = 22,
                    BoilTime = 75,
                    EvaporationRate = 8,
                    WortVolume = 27,
                    BoilLoss = 5,
                    PreBoilGravity = 12.8m,
                    FermentationLoss = 2,
                    DryHopLoss = 1,
                    MashEfficiency = 80,
                    WaterToGrainRatio = 3.2m,
                    MashWaterVolume = 16.5m,
                    TotalMashVolume = 20,
                    CreatedById = "todo",
                }
            };
    }

    public static IEnumerable<RecipeTypeEntity> GetRecipeTypeEntity()
    {
        return new List<RecipeTypeEntity>()
        {
            new()
            {
                Id= 1,
                Name="Zacieranie"
            },
            new()
            {
                Id= 2,
                Name="Inne"
            },
        };
    }

    public static IEnumerable<BeerStyleEntity> GetBeerStyleEntity()
    {
        return new List<BeerStyleEntity>()
        {
            new()
            {
                Id= 1,
                Name="IPA"
            },
            new()
            {
                Id= 2,
                Name="APA"
            },
            new()
            {
                Id= 3,
                Name="Porter"
            },
            new()
            {
                Id= 4,
                Name="Lager"
            },
        };
    }

    internal static IEnumerable<RecipeFermentingIngredient> GetRecipeFermentingIngredient()
    {
        return new List<RecipeFermentingIngredient>()
        {
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                Quantity = 1.13m,
            },
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                Quantity = 21.21m,
            },
            new()
            {
                RecipeId = 2,
                Recipe = null!,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                Quantity = 13.4m,
            }
        };
    }

    internal static IEnumerable<RecipeHop> GetRecipeHop()
    {
        return new List<RecipeHop>()
        {
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                HopUnitId = 1,
                HopUnit = null!,
                Quantity = 11.13m,
            },
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                HopUnitId = 2,
                HopUnit = null!,
                Quantity = 1.21m,
            },
            new()
            {
                RecipeId = 2,
                Recipe = null!,
                HopUnitId = 1,
                HopUnit = null!,
                Quantity = 11.4m,
            }
        };
    }

    internal static IEnumerable<RecipeYeast> GetRecipeYeast()
    {
        return new List<RecipeYeast>()
        {
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                YeastUnitId = 1,
                YeastUnit = null!,
                Quantity = 11.13m,
            },
            new()
            {
                RecipeId = 1,
                Recipe = null!,
                YeastUnitId = 2,
                YeastUnit = null!,
                Quantity = 1.21m,
            },
            new()
            {
                RecipeId = 2,
                Recipe = null!,
                YeastUnitId = 1,
                YeastUnit = null!,
                Quantity = 11.4m,
            }
        };
    }
}
