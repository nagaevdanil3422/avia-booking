using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Airline"/> для Entity Framework Core.
    /// </summary>
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="Airline"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Airlines");

            //Первичный ключч
            builder.HasKey(c => c.Id);

            // ISO-код — обязательно, ровно 2 символа, уникально
            builder.Property(c => c.IataCode).IsRequired().HasMaxLength(2).IsFixedLength();
            builder.HasIndex(c => c.IataCode).IsUnique();

            //Название аэропорта максимум 200 символов
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

            //внешний ключ на город
            builder.HasOne(c => c.Country).WithMany(c => c.Airlines).HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
