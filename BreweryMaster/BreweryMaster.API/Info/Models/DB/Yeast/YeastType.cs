using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    public class YeastType
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}