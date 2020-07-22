using ComputerBuildService.Shared.Models;
using ComputerBuildService.Shared.Models.IntegratedModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuildService.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Processor> Processors { get; set; }

        public DbSet<IntegratedProcessor> IntegratedProcessors { get; set; }

        public DbSet<CpuСooler> CpuСoolers { get; set; }

        public DbSet<GraphicsCard> GraphicsCards { get; set; }

        public DbSet<IntegratedGraphics> IntegratedGraphics { get; set; }

        public DbSet<HardDrive> HardDrives { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<RandomAccessMemory> RandomAccessMemorys { get; set; }

        public DbSet<PowerSupply> PowerSupplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.IntegratedGraphics)
                .WithMany(gpu => gpu.Motherboards)
                .HasForeignKey(m => m.IntegratedGraphicsId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.IntegratedProcessor)
                .WithMany(cpu => cpu.Motherboards)
                .HasForeignKey(m => m.IntegratedProcessorId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Processor>()
                .HasOne(cpu => cpu.IntegratedGraphics)
                .WithMany(ig => ig.Processors)
                .HasForeignKey(cpu => cpu.IntegratedGraphicsId);

            modelBuilder.Entity<IntegratedGraphics>().HasData(new IntegratedGraphics[]
            {
                new IntegratedGraphics
                {
                   Id = 1,
                   Name = "vega 8",
                   VideoMemoryAmount = 1250,
                   VideoMemoryType = "DDR4",
                   FrequencyGraphicsProcessor = 1600,
                   FrequencyVideoMemory = 2048
                }
            });

            modelBuilder.Entity<Processor>().HasData(new Processor[] 
            {
                new Processor
                {
                   Id = 1,
                   Maker = "AMD",
                   Socket ="AM4",
                   FrequencyCore = 2500,
                   Model = "1600",
                   RangeOf = "Ryzen 5",
                   NumberOfCores = 6,
                   IntegratedGraphicsId = 1
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
