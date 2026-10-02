using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Самолет" 
    /// </summary>
    public class Aircraft
    {
        /// <summary>
        /// Id самолета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Модель (например, Boeing 737-800)
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Бортовой номер
        /// </summary>
        public string RegistrationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Количество мест
        /// </summary>
        public int SeatsCount { get; set; }

        /// <summary>
        /// Внешний ключ на авиакомпанию
        /// </summary>
        public int AirlineId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Airline Airline { get; set; }

        /// <summary>
        /// Рейсы этого самолёта
        /// </summary>
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();

    }
}
