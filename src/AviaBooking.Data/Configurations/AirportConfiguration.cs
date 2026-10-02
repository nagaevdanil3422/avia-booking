using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Airport"/> для Entity Framework Core.
    /// </summary>
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="Airport"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Airports");

            //Первичный ключч
            builder.HasKey(c => c.Id);

            // ISO-код — обязательно, ровно 3 символа, уникально
            builder.Property(c => c.lataCode).IsRequired().HasMaxLength(3).IsFixedLength();

            // ISO-код — обязательно, ровно 3 символа, уникально
            builder.HasIndex(c => c.lataCode).IsUnique();

            //Название аэропорта максимум 200 символов
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

            //внешний ключ на город
            builder.HasOne(c => c.City).WithMany(c => c.Airports).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
