using BookWebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebStore.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {           
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasOne(category => category.Category);

            builder.Entity<Product>()
                .HasOne(type => type.CoverType);
        }
    }
}