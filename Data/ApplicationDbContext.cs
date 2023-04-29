using Microsoft.EntityFrameworkCore;
using Shop.ASP_NET.Models;

namespace Shop.ASP_NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }

        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
