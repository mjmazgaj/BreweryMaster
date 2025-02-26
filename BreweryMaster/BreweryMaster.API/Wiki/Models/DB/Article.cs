using BreweryMaster.API.User.Models.Users.DB;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Wiki.Models
{
    /// <summary>
    /// Represents an article in the wiki system.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// The unique identifier for the article.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the article.
        /// </summary>
        [MaxLength(256)]
        public required string Title { get; set; }

        /// <summary>
        /// The unique identifier of the linked Google Docs document.
        /// </summary>
        [MaxLength(256)]
        public required string GoogleDocId { get; set; }

        /// <summary>
        /// The category ID of the article.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The category entity the article belongs to.
        /// </summary>
        public required ArticleCategory Category { get; set; }

        /// <summary>
        /// The ID of the user who created the article.
        /// </summary>
        [MaxLength(450)]
        public required string CreatedById { get; set; }

        /// <summary>
        /// The user entity who created the article.
        /// </summary>
        public required ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// The timestamp when the article was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The timestamp of the last modification, if any.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// The ID of the user who last modified the article.
        /// </summary>
        public string? ModifiedById { get; set; }

        /// <summary>
        /// The user entity who last modified the article.
        /// </summary>
        public ApplicationUser? ModifiedBy { get; set; }

        /// <summary>
        /// The removal indicator.
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
