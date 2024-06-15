using Microsoft.EntityFrameworkCore;
using ElectronicsApplication.Models;

namespace ElectronicsApplication.Data
{
    /// <summary>
    /// class to set the dbcontext 
    /// </summary>
    public class ElectronicDbContext : DbContext
    {
        public ElectronicDbContext(DbContextOptions<ElectronicDbContext> options) : base(options)
        {
        }
        public DbSet<Electronics> Electronics { get; set; }
    }
}
