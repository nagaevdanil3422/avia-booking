using AviaBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="User"/> для Entity Framework Core.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Настраивает маппинг сущности <see cref="User"/> на таблицу базы данных.
        /// </summary>
        /// <param name="builder">Построитель конфигурации сущности.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Имя таблицы в БД
            builder.ToTable("Users");

            //Первичный ключч
            builder.HasKey(c => c.Id);

            //email максимум 250 символов, уникален
            builder.Property(c => c.Email).IsRequired().HasMaxLength(250);
            builder.HasIndex(c => c.Email).IsUnique();

            //Хэш пароля максимум 500 символов (с запасом)
            builder.Property(c => c.PasswordHash).IsRequired().HasMaxLength(500);

            //Имя пользователья максимум 100 символов
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);

            //Фамилия пользователья максимум 100 символов
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);

            //Роль пользователя 
            builder.Property(c => c.UserRole).IsRequired().HasConversion<int>();

            //Дата регистрации not null
            builder.Property(c => c.CreatedAt).IsRequired();
        }
        
    }
}
