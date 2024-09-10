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
        public DbSet<SalerStock> SalerStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // The primary key of entity Brewer
            modelBuilder.Entity<Brewer>()
                .HasKey(b => new { b.Id });

            // The primary key of entity Saler
            modelBuilder.Entity<Saler>()
                .HasKey(s => new { s.Id });

            // The primary key of entity Beer 
            modelBuilder.Entity<Beer>()
                .HasKey(b => new { b.Id });

            // The primary key of entity SalerStock
            modelBuilder.Entity<SalerStock>()
                .HasKey(ss => new { ss.SalerId, ss.BeerId });

            // one-to-many relationship between Saler and SalerStock
            modelBuilder.Entity<Saler>()
                .HasMany(s => s.salerStocks)
                .WithOne()
                .HasForeignKey(ss => ss.SalerId);

            // one-to-many relationship between Beer and SalerStock
            /*modelBuilder.Entity<SalerStock>()
                .HasOne(ss => ss.Beer)
                .WithMany(b => b.salerStocks)
                .HasForeignKey(ss => new { ss.BeerId })
                .OnDelete(DeleteBehavior.Cascade);*/




            modelBuilder.Entity<Beer>()
                .Property(b => b.Price)
                .HasColumnType("decimal(19,4)"); // Adjust precision and scale of price column


            base.OnModelCreating(modelBuilder);
        }
    }
}
