using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class Yeast
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
        public int TypeId { get; set; }
        public required YeastType Type { get; set; }
        public int FormId { get; set; }
        public required YeastForm Form { get; set; }
        [MaxLength(255)]
        public string? Producer { get; set; }
        public bool IsRemoved { get; set; }
        public string? Info { get; set; }
    }
}
