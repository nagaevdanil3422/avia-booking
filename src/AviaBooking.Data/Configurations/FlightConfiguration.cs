using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Flight"/> для Entity Framework Core.
    /// </summary>
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="Flight"/> на таблицу базы данных.
        /// </summary>
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flights");
            builder.HasKey(f => f.Id);

            // Номер рейса — обязателен, максимум 10 символов
            builder.Property(f => f.FlightNumber).IsRequired().HasMaxLength(10);

            // Время вылета и прилёта — обязательны
            builder.Property(f => f.DepartureTime).IsRequired();
            builder.Property(f => f.ArrivalTime).IsRequired();

            // Базовая цена — decimal(18,2)
            builder.Property(f => f.BasePrice).IsRequired().HasColumnType("decimal(18,2)");

            // Статус — enum как int
            builder.Property(f => f.Status).IsRequired().HasConversion<int>();

            //Связь с Aircraft(вылет 1 ко многим)
            builder.HasOne(f => f.Airline).WithMany(f => f.Flights).HasForeignKey(f => f.AirlineId).OnDelete(DeleteBehavior.Restrict);

            //Связь с Aircraft(вылет 1 ко многим)
            builder.HasOne(f => f.Aircraft).WithMany(a => a.Flights).HasForeignKey(f => f.AircraftId).OnDelete(DeleteBehavior.Restrict);

            //Связь с Airport(вылет 1 ко многим)
            builder.HasOne(f => f.DepartureAirport).WithMany(a => a.DepartureFlights).HasForeignKey(f => f.DepartureAirportId).OnDelete(DeleteBehavior.Restrict);

            //Связь с Airport(вылет 1 ко многим)
            builder.HasOne(f => f.ArrivalAirport).WithMany(a => a.ArrivalFlights).HasForeignKey(f => f.ArrivalAirportId).OnDelete(DeleteBehavior.Restrict);

            // Индекс на FlightNumber — не unique, потому что рейсы повторяются по дням
            builder.HasIndex(f => f.FlightNumber);
        }
    }
}