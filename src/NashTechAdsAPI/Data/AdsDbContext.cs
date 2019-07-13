using Microsoft.EntityFrameworkCore;
using NashTechAdsAPI.Models;

namespace NashTechAdsAPI.Data
{
    public class AdsDbContext : DbContext
    {
        public AdsDbContext(DbContextOptions<AdsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category>  Categories { get; set; }

        public DbSet<Ad> Ads { get; set; }
    }
}
