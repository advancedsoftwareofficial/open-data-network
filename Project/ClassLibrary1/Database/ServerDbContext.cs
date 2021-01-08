using AdvancedSoftware.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using NETBoilerplate.Shared.Entity;

namespace NETBoilerplate.DataAccess.Database
{
    public class ServerDbContext : AppDbContext<ServerDbContext>
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Content>().ToTable("Content").HasKey(y => y.Id);
            builder.Entity<Content>().Property(y => y.Timestamp).IsConcurrencyToken();
        }
    }
}
