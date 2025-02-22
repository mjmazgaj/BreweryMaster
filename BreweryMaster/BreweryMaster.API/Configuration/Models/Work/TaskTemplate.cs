namespace BreweryMaster.API.Configuration.Models
{
    public class TaskTemplate
    {
        public required string Title { get; set; }
        public required string Summary { get; set; }
        public int TimeDelay { get; set; }
    }
}
