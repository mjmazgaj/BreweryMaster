using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    public class OrderRequest
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int ContainerId { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [Required]
        public DateTime TargetDate { get; set; }
    }
}
