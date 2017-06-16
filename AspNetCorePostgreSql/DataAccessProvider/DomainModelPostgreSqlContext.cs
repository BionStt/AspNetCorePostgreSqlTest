using AspNetCorePostgreSql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AspNetCorePostgreSql.DataAccessProvider
{
    // >dotnet ef migration add testMigration in AspNet5MultipleProject
    public class DomainModelPostgreSqlContext : DbContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Suite> Suites { get; set; }

        public DbSet<Resident> Residents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Building>().HasKey(m => m.Id);
            builder.Entity<Suite>().HasKey(m => m.Id);
            builder.Entity<Resident>().HasKey(m => m.Id);

            builder.Entity<Suite>()
                .HasOne(s => s.Building)
                .WithMany(b => b.Suites);

            builder.Entity<Resident>()
                .HasOne(r => r.Suite)
                .WithMany(s => s.Residents);

            // shadow properties
            builder.Entity<Building>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<Suite>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<Resident>().Property<DateTime>("UpdatedTimestamp");

            builder.Entity<Building>().Property(f => f.Id).UseNpgsqlSerialColumn();
            builder.Entity<Suite>().Property(f => f.Id).UseNpgsqlSerialColumn();
            builder.Entity<Resident>().Property(f => f.Id).UseNpgsqlSerialColumn();

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<Suite>();
            UpdateUpdatedProperty<Building>();
            UpdateUpdatedProperty<Resident>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}