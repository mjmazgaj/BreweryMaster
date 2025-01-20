using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderUpdateRequest : OrderRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
