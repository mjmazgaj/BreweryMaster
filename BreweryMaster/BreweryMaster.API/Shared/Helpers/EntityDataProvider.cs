using BreweryMaster.API.Info.Models.Item;
using BreweryMaster.API.Shared.Models.DB;
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
}
