using BreweryMaster.API.Shared.Models.DB;

public static class DataProvider
{
    public static IEnumerable<UnitEntity> GetUnitEntity()
    {
        return new List<UnitEntity>()
        {
            new()
            {
                Id= 1,
                Name="kg"
            },
            new()
            {
                Id= 2,
                Name="mg"
            },
            new()
            {
                Id= 3,
                Name="l"
            },
            new()
            {
                Id= 4,
                Name="hl"
            },
        };
    }
}
