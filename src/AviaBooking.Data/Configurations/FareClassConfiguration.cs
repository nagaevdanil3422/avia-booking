using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="FareClass"/> для Entity Framework Core.
    /// </summary>
    public class FareClassConfiguration : IEntityTypeConfiguration<FareClass>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="FareClass"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<FareClass> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("FareClasses");

            //Первичный ключч
            builder.HasKey(c => c.Id);

            //Название класса обслуживания максимум 50 символов
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Name).IsUnique();

            //Множитель цены до 18.2
            builder.Property(c => c.Multiplier).IsRequired().HasPrecision(18,2);
        }

    }
}
