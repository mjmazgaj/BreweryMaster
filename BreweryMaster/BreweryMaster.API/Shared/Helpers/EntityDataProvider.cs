using BreweryMaster.API.Info.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.Work.Models.DB;
using Microsoft.AspNetCore.Identity;

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

    public static IEnumerable<TaskStatusEntity> GetTaskStatusEntities()
    {
        return new List<TaskStatusEntity>()
            {
                new()
                {
                    Id = 1,
                    Name = "Todo"
                },
                new()
                {
                    Id = 2,
                    Name = "InProgress"
                },
                new()
                {
                    Id = 3,
                    Name = "Done"
                }
            };
    }

    public static IEnumerable<IdentityRole> GetIdentityRoles()
    {
        return new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = "manager",
                Name = "manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "supervisor",
                Name = "supervisor",
                NormalizedName = "SUPERVISOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "brewer",
                Name = "brewer",
                NormalizedName = "BREWER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "employee",
                Name = "employee",
                NormalizedName = "EMPLOYEE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "employeeNotMobile",
                Name = "employeeNotMobile",
                NormalizedName = "EMPLOYEENOTMOBILE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Id = "customer",
                Name = "customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };
    }

    public static IEnumerable<AddressTypeEntity> GetAddressTypes()
    {
        return new List<AddressTypeEntity>()
            {
                new()
                {
                    Id = 1,
                    Name = "Home"
                },
                new()
                {
                    Id = 2,
                    Name = "Delivery"
                },
                new()
                {
                    Id = 3,
                    Name = "Invoice"
                }
            };
    }

    public static IEnumerable<MaterialType> GetMaterialTypes()
    {
        return new List<MaterialType>()
        {
                new()
                {
                    Id = 1,
                    Name = "Glass"
                },
                new()
                {
                    Id = 2,
                    Name = "Metal"
                },
                new()
                {
                    Id = 3,
                    Name = "Plastic"
                }
        };
    }

    public static IEnumerable<OrderStatus> GetOrderStatuses()
    {
        return new List<OrderStatus>()
        {
                new()
                {
                    Id = 1,
                    Name = "NotSet"
                },
                new()
                {
                    Id = 2,
                    Name = "CreatingDocumentation"
                },
                new()
                {
                    Id = 3,
                    Name = "ProductionPreparation"
                },
                new()
                {
                    Id = 4,
                    Name = "Brewing"
                },
                new()
                {
                    Id = 5,
                    Name = "PostBrewingWork"
                },
                new()
                {
                    Id = 6,
                    Name = "Maturation"
                },
                new()
                {
                    Id = 7,
                    Name = "Packaging"
                },
                new()
                {
                    Id = 8,
                    Name = "PreparedForDelivery"
                },
                new()
                {
                    Id = 9,
                    Name = "Completed"
                }
        };
    }
}
