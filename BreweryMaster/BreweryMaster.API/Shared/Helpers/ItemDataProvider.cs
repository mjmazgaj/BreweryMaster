﻿using BreweryMaster.API.Info.Models;

public static class ItemDataProvider
{
    public static IEnumerable<Container> GetContainers()
    {
        return new List<Container>()
        {
            new()
            {
                Id = 1,
                ContainerName ="bottle",
                MaterialId = 1,
                Material = null!,
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 500,
            },
            new()
            {
                Id = 2,
                ContainerName ="bottle",
                MaterialId = 2,
                Material = null!,
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 500,
            },
            new()
            {
                Id = 3,
                ContainerName ="bottle",
                MaterialId = 1,
                Material = null!,
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 300,
            },
            new()
            {
                Id = 4,
                ContainerName ="bottle",
                MaterialId = 2,
                Material = null!,
                UnitEntity = null!,
                UnitEntityId = 5,
                Capacity = 300,
            },
            new()
            {
                Id = 5,
                ContainerName ="keg",
                MaterialId = 3,
                Material = null!,
                UnitEntity = null!,
                UnitEntityId = 3,
                Capacity = 10,
            }
        };
    }

    public static IEnumerable<BeerPrice> GetBeerPrices()
    {
        return new List<BeerPrice>()
        {
            new()
            {
                Id = 1,
                BeerStyleId = 1,
                BeerStyle = null!,
                Price = 2000,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 2,
                BeerStyleId = 2,
                BeerStyle = null!,
                Price = 2500,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 3,
                BeerStyleId = 3,
                BeerStyle = null!,
                Price = 2500,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 4,
                BeerStyleId = 4,
                BeerStyle = null!,
                Price = 1500,
                CreatedOn = DateTime.Now,
            },
        };
    }

    public static IEnumerable<ContainerPrice> GetContainerPrices()
    {
        return new List<ContainerPrice>()
        {
            new()
            {
                Id = 11,
                ContainerId = 1,
                Container = null!,
                Price = 1,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 12,
                ContainerId = 2,
                Container = null!,
                Price = 0.5m,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 13,
                ContainerId = 3,
                Container = null!,
                Price = 1,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 14,
                ContainerId = 4,
                Container = null!,
                Price = 0.5m,
                CreatedOn = DateTime.Now,
            },
            new()
            {
                Id = 15,
                ContainerId = 5,
                Container = null!,
                Price = 25,
                CreatedOn = DateTime.Now,
            },
        };
    }
}
