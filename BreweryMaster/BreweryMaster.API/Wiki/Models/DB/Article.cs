using BreweryMaster.API.User.Models.Users.DB;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Wiki.Models
{
    public class Article
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Title { get; set; }
        [MaxLength(255)]
        public required string GoogleDocId { get; set; }
        public int CategoryId { get; set; }
        public required ArticleCategory Category { get; set; }
        [MaxLength(450)]
        public required string CreatedById { get; set; }
        public required ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedById { get; set; }
        public ApplicationUser? ModifiedBy { get; set; }
        public bool IsRemoved { get; set; }
    }
}
