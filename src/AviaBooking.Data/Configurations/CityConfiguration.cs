using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="City"/> для Entity Framework Core.
    /// </summary>
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="City"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Cities");

            //Первичный ключ
            builder.HasKey(x => x.Id);

            //Название города максимум 100 символов
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //Внешний ключ на страну
            builder.HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
