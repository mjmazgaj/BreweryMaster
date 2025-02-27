using BreweryMaster.API.SharedModule.Validators;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderStatusChangeRequest
    {
        [Required]
        [MinIntValidation]
        public int OrderId { get; set; }

        [Required]
        [MinIntValidation]
        public int OrderStatusId { get; set; }
    }
}
