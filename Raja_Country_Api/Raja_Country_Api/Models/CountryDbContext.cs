using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Raja_Country_Api.Models
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> op) : base(op)
        {

        }
        public DbSet<Country> CountryDetails { get; set; }
        public DbSet<State> StateDetails { get; set; }
        public DbSet<District> DistrictDetails { get; set; }
        public DbSet<Location> LocationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("CountryDetails");
            modelBuilder.Entity<State>().ToTable("StateDetails");
            modelBuilder.Entity<District>().ToTable("DistrictDetails");

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<District>()
                .HasIndex(d => d.Name)
                .IsUnique();
        }
    }
}
