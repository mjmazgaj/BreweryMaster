using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Requests
{
    public class UserFilterRequest
    {
        [MaxLength(256)]
        public string? Email { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public bool? IsCompany { get; set; }

        [MaxLength(450)]
        public string? RoleId { get; set; }
    }
}
