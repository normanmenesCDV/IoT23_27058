using Microsoft.EntityFrameworkCore;
using Lab2.Infrastructure.Entities;
using Lab2.Infrastructure.Configuration;

namespace Lab2.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<PersonEntity> Person { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
        }
    }
}