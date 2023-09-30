﻿using Microsoft.EntityFrameworkCore;
using PadelIT.Models;

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

                entity.Property(e => e.Name).HasColumnType("text");
            });
        }
    }
}