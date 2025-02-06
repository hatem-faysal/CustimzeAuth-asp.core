using Microsoft.EntityFrameworkCore;
using CustimzeAuth.Models;

namespace CustimzeAuth.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .ToTable("Users");
        }        
        public DbSet<User> Users { get; set; }
    }
}
