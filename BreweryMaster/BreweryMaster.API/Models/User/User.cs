using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Models.User
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}