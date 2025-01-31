using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryMaster.API.Info.Models.DB.Yeast
{
    public class YeastQuantity
    {
        public int Id { get; set; }
        public int YeastUnitId { get; set; }
        public required YeastUnit YeastUnit { get; set; }
        public bool IsRemoved { get; set; }
        public string? Info { get; set; }
    }
}
