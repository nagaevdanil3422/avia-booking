using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Страна"
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ID страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название страны (например Россия)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Код ISO (например, "RU", "US")
        /// </summary>
        public string IsoCode { get; set; } = string.Empty;

        /// <summary>
        /// Навигация: города этой страны
        /// </summary>
        public ICollection<City> Cities { get; set; } = new List<City>();

        /// <summary>
        /// Навигация: Авиакомпании заригистрированные в этой стране
        /// </summary>
        public ICollection<Airline> Airlines { get; set; } = new List<Airline>();
    }
}
