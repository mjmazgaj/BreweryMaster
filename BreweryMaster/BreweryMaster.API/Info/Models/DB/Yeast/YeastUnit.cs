using BreweryMaster.API.Info.Models.DB.Yeast;

namespace BreweryMaster.API.Info.Models
{
    public class YeastUnit
    {
        public int Id { get; set; }
        public int YeastId { get; set; }
        public required Yeast Yeast { get; set; }
        public int UnitId { get; set; }
        public required UnitEntity Unit { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<YeastOrdered> YeastOrdered { get; set; } = new List<YeastOrdered>();
        public ICollection<YeastReserved> YeastReserved { get; set; } = new List<YeastReserved>();
        public ICollection<YeastStored> YeastStored { get; set; } = new List<YeastStored>();
    }
}
