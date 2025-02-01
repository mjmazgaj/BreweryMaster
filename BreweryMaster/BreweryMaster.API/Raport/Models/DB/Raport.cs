namespace BreweryMaster.API.RaportModule.Models
{
    public class Raport
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int CategoryId { get; set; }
        public required RaportCategory Category { get; set; }
        public required string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
