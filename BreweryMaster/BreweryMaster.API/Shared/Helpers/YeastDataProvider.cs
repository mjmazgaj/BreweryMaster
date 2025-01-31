using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Models.DB.Yeast;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class YeastDataProvider
    {
        public static IEnumerable<YeastType> GetYeastType()
        {
            return new List<YeastType>()
            {
                new()
                {
                    Id= 1,
                    Name="Lager"
                },
                new()
                {
                    Id= 2,
                    Name="Ale"
                },
            };
        }

        public static IEnumerable<YeastForm> GetYeastForm()
        {
            return new List<YeastForm>()
            {
                new()
                {
                    Id= 1,
                    Name="Plynna"
                },
                new()
                {
                    Id= 2,
                    Name="Kostka"
                },
            };
        }

        public static IEnumerable<YeastUnit> GetYeastUnit()
        {
            return new List<YeastUnit>
            {
                new()
                {
                    Id=1,
                    YeastId=1,
                    Yeast = null!,
                    UnitId=1,
                    Unit = null!
                },
                new()
                {
                    Id=2,
                    YeastId=1,
                    Yeast = null!,
                    UnitId=2,
                    Unit = null!
                },
                new()
                {
                    Id=3,
                    YeastId=1,
                    Yeast = null!,
                    UnitId=3,
                    Unit = null!
                },
                new()
                {
                    Id=4,
                    YeastId=2,
                    Yeast = null!,
                    UnitId=1,
                    Unit = null!
                },
                new()
                {
                    Id=5,
                    YeastId=2,
                    Yeast = null!,
                    UnitId=2,
                    Unit = null!
                }
            };
        }
        public static IEnumerable<Yeast> GetYeasts()
        {
            return new List<Yeast>()
            {
                    new ()
                {
                    Id = 1,
                    Name = "Saflager W-34/70",
                    TypeId = 1,
                    Type = null!,
                    FormId = 1,
                    Form = null!,
                    Producer = "Fermentis",
                    Info = ""
                },
                new ()
                {
                    Id = 2,
                    Name = "US-05",
                    TypeId = 2,
                    Type = null!,
                    FormId = 2,
                    Form = null!,
                    Producer = "Fermentis",
                    Info = ""
                },
                new ()
                {
                    Id = 3,
                    Name = "Wyeast 3724 Belgian Saison",
                    TypeId = 2,
                    Type = null!,
                    FormId = 1,
                    Form = null!,
                    Producer = "Wyeast",
                    Info = ""
                }
            };
        }

        public static IEnumerable<YeastOrdered> GetYeastOrdered()
        {
            return new List<YeastOrdered>()
        {
            new()
            {
                Id = 1,
                YeastUnitId = 1,
                YeastUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(3),
                OrderedDate = DateTime.Now.AddDays(-3),
                OrderedQuantity = 10,
                Info = "Yeast Ordered Info 1"
            },
            new()
            {
                Id = 2,
                YeastUnitId = 1,
                YeastUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(1),
                OrderedDate = DateTime.Now.AddDays(-2),
                OrderedQuantity = 3,
                Info = "Yeast Ordered Info 2"
            },
            new()
            {
                Id = 3,
                YeastUnitId = 2,
                YeastUnit = null!,
                ExpectedDate = DateTime.Now.AddDays(2),
                OrderedDate = DateTime.Now.AddDays(-4),
                OrderedQuantity = 33,
                Info = "Yeast Ordered Info 1"
            }
        };
        }

        public static IEnumerable<YeastReserved> GetYeastReserved()
        {
            return new List<YeastReserved>()
        {
            new()
            {
                Id = 4,
                YeastUnitId = 1,
                YeastUnit = null!,
                ReservedQuantity = 4,
                ReservationDate = DateTime.Now.AddDays(-2),
                Info = "Yeast Unit Reserved Info 1"
            },
            new()
            {
                Id = 5,
                YeastUnitId = 2,
                YeastUnit = null!,
                ReservedQuantity = 7,
                ReservationDate = DateTime.Now.AddDays(-1),
                Info = "Yeast Unit Reserved Info 1"
            },
            new()
            {
                Id = 6,
                YeastUnitId = 1,
                YeastUnit = null!,
                ReservedQuantity = 10,
                ReservationDate = DateTime.Now.AddDays(-3),
                Info = "Yeast Unit Reserved Info 1"
            },
        };
        }

        public static IEnumerable<YeastStored> GetYeastStored()
        {
            return new List<YeastStored>()
        {
            new()
            {
                Id = 7,
                YeastUnitId = 2,
                YeastUnit = null!,
                StoredQuantity = 200,
                Info = "Yeast Unit Stored Info 1"
            },
            new()
            {
                Id = 8,
                YeastUnitId = 2,
                YeastUnit = null!,
                StoredQuantity = 230,
                Info = "Yeast Unit Stored Info 1"
            },
            new()
            {
                Id = 9,
                YeastUnitId = 1,
                YeastUnit = null!,
                StoredQuantity = 300,
                Info = "Yeast Unit Stored Info 1"
            },
        };
        }
    }
}
