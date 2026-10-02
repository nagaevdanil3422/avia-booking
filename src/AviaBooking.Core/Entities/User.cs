using AviaBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Пользователь"
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Хеш пароля (не сам пароль!)
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Роль (enum)
        /// </summary>
        public UserRole UserRole { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Брони пользователя
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
