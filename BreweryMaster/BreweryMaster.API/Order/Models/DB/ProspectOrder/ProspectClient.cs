namespace BreweryMaster.API.OrderModule.Models
{
    public class ProspectClient
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }
        [MaxLength(255)]
        public required string Email { get; set; }
        public ICollection<ProspectOrder>? Orders { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsRemoved { get; set; }
    }
}
