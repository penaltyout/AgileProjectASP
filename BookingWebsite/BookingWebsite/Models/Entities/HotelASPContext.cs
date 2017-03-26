using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingWebsite.Models.Entities
{
    public partial class HotelASPContext : DbContext
    {
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking", "HotelASP");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("Room_Id");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BookingRoom");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "HotelASP");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Statuscode).HasColumnName("statuscode");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "HotelASP");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasColumnName("AspNetUser_Id")
                    .HasMaxLength(450);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });
        }
    }
}