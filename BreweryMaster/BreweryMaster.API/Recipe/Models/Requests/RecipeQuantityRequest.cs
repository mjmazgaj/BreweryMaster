using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeQuantityRequest
    {
        [Precision(8, 2)]
        [Range(0, 1000000)]
        public decimal Quantity { get; set; }
        public string? Info { get; set; }
    }
}
