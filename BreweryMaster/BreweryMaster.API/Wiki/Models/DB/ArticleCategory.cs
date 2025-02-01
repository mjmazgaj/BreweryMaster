using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Wiki.Models
{
    /// <summary>
    /// Represents a category for articles in the wiki system.
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// The id of the article category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}