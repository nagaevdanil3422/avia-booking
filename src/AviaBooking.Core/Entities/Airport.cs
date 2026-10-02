using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Аэропорт"
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// ID аэропорта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код IATA (3 буквы), unique
        /// </summary>
        public string lataCode { get; set; }

        /// <summary>
        /// Название аэропорта
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ нв город
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Рейсы, где это аэропорт вылета
        /// </summary>
        public ICollection<Flight> DepartureFlights { get; set; } = new List<Flight>();

        /// <summary>
        /// Рейсы, где это аэропорт прилёта
        /// </summary>
        public ICollection<Flight> ArrivalFlights { get; set; } = new List<Flight>();

    }
}
