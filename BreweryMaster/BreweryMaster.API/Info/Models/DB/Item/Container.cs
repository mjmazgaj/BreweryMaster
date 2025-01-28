using BreweryMaster.API.Shared.Models.DB;

namespace BreweryMaster.API.Info.Models
{
    public class Container
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string ContainerName { get; set; }
        [MaxLength(255)]
        public string? Material { get; set; }
        public int Capacity { get; set; }
        public int UnitEntityId { get; set; }
        public required UnitEntity UnitEntity { get; set; }
    }
}
