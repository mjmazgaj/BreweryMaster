using BreweryMaster.API.Wiki.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Models.DB
{
    public partial class ApplicationDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<ArticleCategory> ArticleCategories { get; set; }
    }
}
