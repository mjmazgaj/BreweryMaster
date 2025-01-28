using BreweryMaster.API.Info.Models.Item;
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
                    BLGScale = 12.5f,
                    IBUScale = 35,
                    ABVScale = 5.2f,
                    SRMScale = 6.0f,
                    TypeId = 1,
                    StyleId = 2,
                    ExpectedBeerVolume = 20,
                    BoilTime = 60,
                    EvaporationRate = 10,
                    WortVolume = 25,
                    BoilLoss = 5,
                    PreBoilGravity = 11.5f,
                    FermentationLoss = 1,
                    DryHopLoss = 1,
                    MashEfficiency = 75,
                    WaterToGrainRatio = 3,
                    MashWaterVolume = 15.0f,
                    TotalMashVolume = 18,
                    FermentingIngredients = null!,
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Smaczne piwo",
                    BLGScale = 15.0f,
                    IBUScale = 45,
                    ABVScale = 6.0f,
                    SRMScale = 40.0f,
                    TypeId = 1,
                    StyleId = 3,
                    ExpectedBeerVolume = 18,
                    BoilTime = 90,
                    EvaporationRate = 12,
                    WortVolume = 22,
                    BoilLoss = 4,
                    PreBoilGravity = 13.5f,
                    FermentationLoss = 2,
                    DryHopLoss = 0,
                    MashEfficiency = 70,
                    WaterToGrainRatio = 2.5f,
                    MashWaterVolume = 14.0f,
                    TotalMashVolume = 16,
                    FermentingIngredients = null!,
                },
                new Recipe
                {
                    Id = 3,
                    Name = "Swietne piwo",
                    BLGScale = 14.0f,
                    IBUScale = 60,
                    ABVScale = 6.5f,
                    SRMScale = 8.0f,
                    TypeId = 2,
                    StyleId = 4,
                    ExpectedBeerVolume = 22,
                    BoilTime = 75,
                    EvaporationRate = 8,
                    WortVolume = 27,
                    BoilLoss = 5,
                    PreBoilGravity = 12.8f,
                    FermentationLoss = 2,
                    DryHopLoss = 1,
                    MashEfficiency = 80,
                    WaterToGrainRatio = 3.2f,
                    MashWaterVolume = 16.5f,
                    TotalMashVolume = 20,
                    FermentingIngredients = null!,
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
                Id = 1,
                RecipeId = 1,
                Recipe = null!,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                Quantity = 1.13f,
            },
            new()
            {
                Id = 2,
                RecipeId = 1,
                Recipe = null!,
                FermentingIngredientUnitId = 2,
                FermentingIngredientUnit = null!,
                Quantity = 21.21f,
            },
            new()
            {
                Id = 3,
                RecipeId = 2,
                Recipe = null!,
                FermentingIngredientUnitId = 1,
                FermentingIngredientUnit = null!,
                Quantity = 13.4f,
            }
        };
    }
}
