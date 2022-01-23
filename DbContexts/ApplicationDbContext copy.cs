using Microsoft.EntityFrameworkCore;
using PrintManager.Enums;
using PrintManager.Models;

namespace PrintManager.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Copier> Copiers { get; set; }
        public DbSet<Scanner> Scanners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
            .HasDiscriminator<DeviceType>("DeviceType")
            .HasValue<Printer>(DeviceType.Printer)
            .HasValue<Scanner>(DeviceType.Scanner)
            .HasValue<Copier>(DeviceType.Copier);

        }
    }
}