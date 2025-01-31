using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class HopDataProvider
    {
        public static IEnumerable<HopUnit> GetHopUnit()
        {
            return new List<HopUnit>
            {
                new()
                {
                    Id=1,
                    HopId=1,
                    Hop = null!,
                    UnitId=1,
                    Unit = null!
                },
                new()
                {
                    Id=2,
                    HopId=1,
                    Hop = null!,
                    UnitId=2,
                    Unit = null!
                },
                new()
                {
                    Id=3,
                    HopId=1,
                    Hop = null!,
                    UnitId=3,
                    Unit = null!
                },
                new()
                {
                    Id=4,
                    HopId=2,
                    Hop = null!,
                    UnitId=1,
                    Unit = null!
                },
                new()
                {
                    Id=5,
                    HopId=2,
                    Hop = null!,
                    UnitId=2,
                    Unit = null!
                }
            };
        }

        public static IEnumerable<Hop> GetHops()
        {
            return new List<Hop>()
            {
                new Hop
                {
                    Id = 1,
                    Name = "Cascade",
                    AlphaAcids = 5.5m
                },
                new Hop
                {
                    Id = 2,
                    Name = "Citra",
                    AlphaAcids = 12.0m
                },
                new Hop
                {
                    Id = 3,
                    Name = "Saaz",
                    AlphaAcids = 3.2m
                }
            };
        }

        public static IEnumerable<HopOrdered> GetHopOrdered()
        {
            return new List<HopOrdered>()
            {
                new()
                {
                    Id = 1,
                    HopUnitId = 1,
                    HopUnit = null!,
                    ExpectedDate = DateTime.Now.AddDays(3),
                    OrderedDate = DateTime.Now.AddDays(-3),
                    OrderedQuantity = 10,
                    Info = "Hop Ordered Info 1"
                },
                new()
                {
                    Id = 2,
                    HopUnitId = 1,
                    HopUnit = null!,
                    ExpectedDate = DateTime.Now.AddDays(1),
                    OrderedDate = DateTime.Now.AddDays(-2),
                    OrderedQuantity = 3,
                    Info = "Hop Ordered Info 2"
                },
                new()
                {
                    Id = 3,
                    HopUnitId = 2,
                    HopUnit = null!,
                    ExpectedDate = DateTime.Now.AddDays(2),
                    OrderedDate = DateTime.Now.AddDays(-4),
                    OrderedQuantity = 33,
                    Info = "Hop Ordered Info 1"
                }
            };
        }

        public static IEnumerable<HopReserved> GetHopReserved()
        {
            return new List<HopReserved>()
            {
                new()
                {
                    Id = 4,
                    HopUnitId = 1,
                    HopUnit = null!,
                    ReservedQuantity = 4,
                    ReservationDate = DateTime.Now.AddDays(-2),
                    Info = "Hop Unit Reserved Info 1"
                },
                new()
                {
                    Id = 5,
                    HopUnitId = 2,
                    HopUnit = null!,
                    ReservedQuantity = 7,
                    ReservationDate = DateTime.Now.AddDays(-1),
                    Info = "Hop Unit Reserved Info 1"
                },
                new()
                {
                    Id = 6,
                    HopUnitId = 1,
                    HopUnit = null!,
                    ReservedQuantity = 10,
                    ReservationDate = DateTime.Now.AddDays(-3),
                    Info = "Hop Unit Reserved Info 1"
                },
            };
        }

        public static IEnumerable<HopStored> GetHopStored()
        {
            return new List<HopStored>()
            {
                new()
                {
                    Id = 7,
                    HopUnitId = 2,
                    HopUnit = null!,
                    StoredQuantity = 200,
                    Info = "Hop Unit Stored Info 1"
                },
                new()
                {
                    Id = 8,
                    HopUnitId = 2,
                    HopUnit = null!,
                    StoredQuantity = 230,
                    Info = "Hop Unit Stored Info 1"
                },
                new()
                {
                    Id = 9,
                    HopUnitId = 1,
                    HopUnit = null!,
                    StoredQuantity = 300,
                    Info = "Hop Unit Stored Info 1"
                },
            };
        }
    }
}
