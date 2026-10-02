using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Country"/> для Entity Framework Core.
    /// </summary>
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="Country"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Countries");

            //Первичный ключ
            builder.HasKey(c => c.Id);

            //Название страны максимум 100 символов
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            // ISO-код — обязательно, ровно 2 символа, уникально
            builder.Property(p => p.IsoCode).IsRequired().HasMaxLength(2).IsFixedLength();

            // ISO-код — обязательно, ровно 2 символа, уникально
            builder.HasIndex(c => c.IsoCode).IsUnique();

        }
    }
}
