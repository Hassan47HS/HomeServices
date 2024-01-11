using Home_Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Home_Service
{
    public class HomeServiceDB: IdentityDbContext<IdentityUser>
    {
        public HomeServiceDB(DbContextOptions<HomeServiceDB> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            seedRoles(builder);
        }
        public DbSet <User> users { get; set; }
        public DbSet <Services> services { get; set; }
        public DbSet <Category> categories { get; set; }
        private void seedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Seller", ConcurrencyStamp = "2", NormalizedName = "Seller" },
                new IdentityRole() { Name = "Customer", ConcurrencyStamp = "3", NormalizedName = "Customer" }
                );
        }
    }
}
