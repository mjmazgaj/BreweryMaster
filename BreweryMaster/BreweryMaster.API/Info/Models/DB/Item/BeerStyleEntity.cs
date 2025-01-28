namespace BreweryMaster.API.Info.Models
{
    public class BeerStyleEntity
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
