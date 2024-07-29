using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(entry => entry.Entity
                                                            .GetType()
                                                            .GetProperty("CreatedAt") != null);
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
