using ComputerBuildService.DAL.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ComputerBuildService.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CompatibilityPropertyEntity> CompatibleProperties { get; set; }

        public DbSet<HardwareItemEntity> HardwareItems { get; set; }

        public DbSet<HardwareTypeEntity> HardwareTypes { get; set; }

        public DbSet<ManufacturerEntity> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompatibilityPropertyEntity>().HasIndex(n => n.PropertyName).IsUnique();
            modelBuilder.Entity<HardwareTypeEntity>().HasIndex(n => n.TypeName).IsUnique();
            modelBuilder.Entity<HardwareItemEntity>().HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<ManufacturerEntity>().HasIndex(n => n.Name).IsUnique();

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
                 .HasKey(t => new { t.ItemId, t.PropertyId });

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
               .HasOne(hi => hi.Item)
               .WithMany(pi => pi.PropertysItems)
               .HasForeignKey(fk => fk.ItemId);

            modelBuilder.Entity<CompatibilityPropertyHardwareItem>()
                .HasOne(cp => cp.Property)
                .WithMany(pi => pi.PropertysItems)
                .HasForeignKey(fk => fk.PropertyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
