namespace BreweryMaster.API.Log.Models
{
    public class ChangeLog
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string TableName { get; set; }
        [MaxLength(255)]
        public required string ChangeType { get; set; }
        public required string ChangedData { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
