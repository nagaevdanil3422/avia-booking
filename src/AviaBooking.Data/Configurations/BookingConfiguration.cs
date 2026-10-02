using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Booking"/> для Entity Framework Core.
    /// </summary>
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);

            // PNR-код — 6 символов, уникальный
            builder.Property(b => b.BookingCode).IsRequired().HasMaxLength(6).IsFixedLength();
            builder.HasIndex(b => b.BookingCode).IsUnique();

            builder.Property(b => b.CreatedAt).IsRequired();

            builder.Property(b => b.Status).IsRequired().HasConversion<int>();

            builder.Property(b => b.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");

            // Связь с User (1:N)
            builder.HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
