using Microsoft.EntityFrameworkCore;
using PadelIT.Database.Models;

namespace PadelIT.Database
{
    public class SpelarbasenContext : DbContext
    {

        public SpelarbasenContext(DbContextOptions<SpelarbasenContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingView> BookingViews { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("BookingView");

                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
            });
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Bookings");

            });modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");
            });
        }
    }
}
