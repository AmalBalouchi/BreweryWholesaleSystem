﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Alcohol")
                        .HasColumnType("float");

                    b.Property<int>("BrewerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Domain.Entities.Brewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brewers");
                });

            modelBuilder.Entity("Domain.Entities.Saler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salers");
                });

            modelBuilder.Entity("Domain.Entities.SalerStock", b =>
                {
                    b.Property<int>("SalerId")
                        .HasColumnType("int");

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SalerId", "BeerId");

                    b.ToTable("SalerStocks");
                });

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.HasOne("Domain.Entities.Brewer", null)
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.SalerStock", b =>
                {
                    b.HasOne("Domain.Entities.Saler", null)
                        .WithMany("salerStocks")
                        .HasForeignKey("SalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Brewer", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("Domain.Entities.Saler", b =>
                {
                    b.Navigation("salerStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
