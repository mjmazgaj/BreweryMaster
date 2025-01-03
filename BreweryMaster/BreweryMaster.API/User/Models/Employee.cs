namespace BreweryMaster.API.UserModule.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public required string Forename { get; set; }
        public required string Surname { get; set; }
        public int? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
