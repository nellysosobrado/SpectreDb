using Microsoft.EntityFrameworkCore;
using SpectreTablesToRefactor.Models;

namespace SpectreTablesToRefactor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
