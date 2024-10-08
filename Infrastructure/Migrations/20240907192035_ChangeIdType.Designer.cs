﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240907192035_ChangeIdType")]
    partial class ChangeIdType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Alcohol")
                        .HasColumnType("float");

                    b.Property<Guid>("BrewerId")
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brewers");
                });

            modelBuilder.Entity("Domain.Entities.Saler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salers");
                });

            modelBuilder.Entity("Domain.Entities.SalerStock", b =>
                {
                    b.Property<Guid>("SalerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SalerId", "BeerId");

                    b.HasIndex("BeerId");

                    b.ToTable("salerStocks");
                });

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.HasOne("Domain.Entities.Brewer", "Brewer")
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewer");
                });

            modelBuilder.Entity("Domain.Entities.SalerStock", b =>
                {
                    b.HasOne("Domain.Entities.Beer", "Beer")
                        .WithMany("salerStocks")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Saler", "Saler")
                        .WithMany("salerStocks")
                        .HasForeignKey("SalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Saler");
                });

            modelBuilder.Entity("Domain.Entities.Beer", b =>
                {
                    b.Navigation("salerStocks");
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
