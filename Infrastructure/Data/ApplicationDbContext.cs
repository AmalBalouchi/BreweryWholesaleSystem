using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        //the ApplicationDbContext constructor uses DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Saler> Salers { get; set; }
        public DbSet<SalerStock> salerStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalerStock>()
                .HasKey(ss => ss.Id);

            modelBuilder.Entity<SalerStock>()
                .HasOne(ss => ss.Saler)
                .WithMany(s => s.salerStocks)
                .HasForeignKey(ss => ss.SalerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalerStock>()
                .HasOne(ss => ss.Beer)
                .WithMany(b => b.salerStocks
                )
                .HasForeignKey(ss => ss.BeerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Beer>()
                .HasOne(b => b.Brewer)
                .WithMany(br => br.Beers)
                .HasForeignKey(b => b.BrewerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Beer>()
                .Property(b => b.Price)
                .HasColumnType("decimal(19,4)"); // Adjust precision and scale of price column


            base.OnModelCreating(modelBuilder);
        }
    }
}
