using Microsoft.EntityFrameworkCore;
using TeledocTest.Models;

namespace TeledocTest.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ClientModel> Clients { get; set; } = null!;
        public DbSet<FounderModel> Founders { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
