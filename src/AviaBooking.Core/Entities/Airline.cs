using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Авиакомпания"
    /// </summary>
    public class Airline
    {
        /// <summary>
        /// ID авиакомпании
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код IATA (2 буквы), unique
        /// </summary>
        public string IataCode { get; set; } = string.Empty;

        /// <summary>
        /// Название авиакомпании
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ на страну
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// 	Навигация на родителя
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Самолёты авиакомпании
        /// </summary>
        public ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();

        /// <summary>
        /// Рейсы авиакомпании
        /// </summary>
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
