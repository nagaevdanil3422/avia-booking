using AviaBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Рейс"
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Id рейса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер рейса (например, SW1234)
        /// </summary>
        public string FlightNumber { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ на авиакомпанию
        /// </summary>
        public int AirlineId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Airline Airline { get; set; }

        /// <summary>
        /// Внешний ключ на самолет
        /// </summary>
        public int AircraftId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Aircraft Aircraft { get; set; }

        /// <summary>
        /// Внешний ключ на аэропорт(вылет)
        /// </summary>
        public int DepartureAirportId { get; set; }

        /// <summary>
        /// Навигация (вылет)
        /// </summary>
        public Airport DepartureAirport { get; set; }

        /// <summary>
        /// Внешний ключ на аэропорт(прилёт)
        /// </summary>
        public int ArrivalAirportId { get; set; }

        /// <summary>
        /// Навигация (прилёт)
        /// </summary>
        public Airport ArrivalAirport { get; set; }

        /// <summary>
        /// Время вылета
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Время прилёта
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Базовая цена
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Статус (enum)
        /// </summary>
        public FlightStatus Status { get; set; }

        /// <summary>
        /// Билеты на этот рейс
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
