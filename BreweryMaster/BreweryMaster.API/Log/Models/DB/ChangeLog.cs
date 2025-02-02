namespace BreweryMaster.API.Log.Models.DB
{
    public class ChangeLog
    {
        public int Id { get; set; }
        public required string TableName { get; set; }
        public required string ChangeType { get; set; }
        public required string ChangedData { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
