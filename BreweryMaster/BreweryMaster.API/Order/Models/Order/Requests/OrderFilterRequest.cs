using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderFilterRequest
    {
        [MaxLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ExpectedBefore { get; set; }

        public DateTime? ExpectedAfter { get; set; }

        [MaxLength(256)]
        public string? RecipeName { get; set; }
    }
}
