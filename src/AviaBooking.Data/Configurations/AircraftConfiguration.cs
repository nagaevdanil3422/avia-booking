using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Aircraft"/> для Entity Framework Core.
    /// </summary>
    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="Aircraft"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Aircrafts");

            //Первичный ключч
            builder.HasKey(c => c.Id);

            // Model — максимум 100 символов
            builder.Property(c => c.Model).IsRequired().HasMaxLength(100);

            //обязательно, ровно 20 символов, уникально
            builder.Property(c => c.RegistrationNumber).IsRequired().HasMaxLength(20).IsFixedLength();
            builder.HasIndex(c => c.RegistrationNumber).IsUnique();

            //Кол-во мест Not null
            builder.Property(c => c.SeatsCount).IsRequired();

            //Внешний ключ на авиакомпанию
            builder.HasOne(c => c.Airline).WithMany(c => c.Aircrafts).HasForeignKey(c => c.AirlineId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
