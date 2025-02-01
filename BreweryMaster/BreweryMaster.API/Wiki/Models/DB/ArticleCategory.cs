using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Wiki.Models.DB
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}