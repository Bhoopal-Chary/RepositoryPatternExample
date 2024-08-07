using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Models;

namespace RepositoryPatternExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
