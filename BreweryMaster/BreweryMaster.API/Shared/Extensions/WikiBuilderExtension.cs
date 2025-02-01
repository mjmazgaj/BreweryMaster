using BreweryMaster.API.Wiki.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class WikiBuilderExtension
    {
        public static void ConfigureWikiEntities(this ModelBuilder builder)
        {

            builder.Entity<Article>(entity =>
            {
                entity.HasOne(x => x.Category)
                        .WithMany()
                        .HasForeignKey(x => x.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
