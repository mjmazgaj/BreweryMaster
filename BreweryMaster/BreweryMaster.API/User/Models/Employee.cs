﻿namespace BreweryMaster.API.UserModule.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
