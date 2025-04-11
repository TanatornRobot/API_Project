using Microsoft.EntityFrameworkCore;
using API_Project.Models;

namespace API_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> pesonaldata2 { get; set; }
    }
}
