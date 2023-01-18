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
    }
}