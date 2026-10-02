using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Ticket"/> для Entity Framework Core.
    /// </summary>
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(t => t.Id);

            // Данные пассажира
            builder.Property(t => t.PassengerFirstName).IsRequired().HasMaxLength(100);

            builder.Property(t => t.PassengerLastName).IsRequired().HasMaxLength(100);

            builder.Property(t => t.PassportNumber).IsRequired().HasMaxLength(20);

            // Место — необязательно, максимум 5 символов (например, "12A")
            builder.Property(t => t.SeatNumber).HasMaxLength(5);

            builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");

            //Связь с Booking (1:N)
            //CASCADE: удаляем Booking — удаляются все его билеты
            builder.HasOne(t => t.Booking).WithMany(b => b.Tickets).HasForeignKey(t => t.BookingId).OnDelete(DeleteBehavior.Cascade);

            //Связь с Flight (1:N)
            builder.HasOne(t => t.Flight).WithMany(f => f.Tickets).HasForeignKey(t => t.FlightId).OnDelete(DeleteBehavior.Restrict);

            //Связь с FareClass (1:N)
            builder.HasOne(t => t.FareClass).WithMany(fc => fc.Tickets).HasForeignKey(t => t.FareClassId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}