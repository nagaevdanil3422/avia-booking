using AviaBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Бронирование"
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Id бронирования
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// PNR-код (6 символов)
        /// </summary>
        public string BookingCode { get; set; }

        /// <summary>
        /// Внешний ключ на пользователя
        /// </summary>
        public int UserId { get; set;  }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 	Статус (enum)
        /// </summary>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// 	Итоговая цена
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Билеты этой брони
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
