using BreweryMaster.API.RaportModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class RaportBuilderExtension
    {
        public static void ConfigureRaport(this ModelBuilder builder)
        {
            builder.Entity<Raport>(entity =>
            {
                entity.HasOne(x=>x.Category)
                        .WithMany()
                        .HasForeignKey(x => x.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
