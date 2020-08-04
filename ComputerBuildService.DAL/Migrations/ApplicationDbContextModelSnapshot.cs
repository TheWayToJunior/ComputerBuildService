﻿// <auto-generated />
using ComputerBuildService.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComputerBuildService.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.CompatibilityPropertyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("PropertyName", "PropertyType")
                        .IsUnique()
                        .HasFilter("[PropertyName] IS NOT NULL AND [PropertyType] IS NOT NULL");

                    b.ToTable("CompatibleProperties");
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.CompatibilityPropertyHardwareItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "PropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("CompatibilityPropertyHardwareItem");
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.HardwareItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("HardwareTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.HasKey("Id");

                    b.HasIndex("HardwareTypeId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("HardwareItems");
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.HardwareTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("HardwareTypes");
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.CompatibilityPropertyHardwareItem", b =>
                {
                    b.HasOne("ComputerBuildService.DAL.Entities.HardwareItemEntity", "Item")
                        .WithMany("PropertysItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerBuildService.DAL.Entities.CompatibilityPropertyEntity", "Property")
                        .WithMany("PropertysItems")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerBuildService.DAL.Entities.HardwareItemEntity", b =>
                {
                    b.HasOne("ComputerBuildService.DAL.Entities.HardwareTypeEntity", "HardwareType")
                        .WithMany("HardwareItems")
                        .HasForeignKey("HardwareTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerBuildService.DAL.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("HardwareItems")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
