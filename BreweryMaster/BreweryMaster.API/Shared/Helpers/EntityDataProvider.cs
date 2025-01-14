using BreweryMaster.API.Shared.Models.DB;

public static class EntityDataProvider
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
            new()
            {
                Id= 5,
                Name="ml"
            },
        };
    }

    public static IEnumerable<Container> GetContainers()
    {
        return new List<Container>()
        {
            new()
            {
                Id = 1,
                ContainerName ="bottle",
                Material = "glass",
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 500,
            },
            new()
            {
                Id = 2,
                ContainerName ="bottle",
                Material = "metal",
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 500,
            },
            new()
            {
                Id = 3,
                ContainerName ="bottle",
                Material = "glass",
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 300,
            },
            new()
            {
                Id = 4,
                ContainerName ="bottle",
                Material = "metal",
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 300,
            },
            new()
            {
                Id = 5,
                ContainerName ="keg",
                Material = "metal",
                UnitEntity = null!,
                UnitEntityId = 3,
                Capacity = 10,
            }
        };
    }
}
