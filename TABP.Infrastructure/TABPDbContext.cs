using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;

namespace TABP.Infrastructure
{
    public class TABPDbContext : DbContext
    {
        public TABPDbContext(DbContextOptions<TABPDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
