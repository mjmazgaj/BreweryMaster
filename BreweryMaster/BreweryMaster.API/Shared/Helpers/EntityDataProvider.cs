﻿using BreweryMaster.API.Info.Models.Item;
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
}
