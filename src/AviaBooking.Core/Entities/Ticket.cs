using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Билет"
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Id билета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// внешний ключ на бронирование
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// внешний ключ на рейс
        /// </summary>
        public int FlightId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Flight Flight { get; set; }

        /// <summary>
        /// Внешний ключ на класс обслуживания
        /// </summary>
        public int FareClassId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public FareClass FareClass { get; set; }

        /// <summary>
        /// Имя пассажира
        /// </summary>
        public string PassengerFirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия пассажира
        /// </summary>
        public string PassengerLastName { get; set; } = string.Empty;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber { get; set; } = string.Empty;

        /// <summary>
        /// Место (может быть null)
        /// </summary>
        public string? SeatNumber { get; set; }

        /// <summary>
        /// Цена (фиксируется при покупке)
        /// </summary>
        public decimal Price { get; set; }

    }
}
