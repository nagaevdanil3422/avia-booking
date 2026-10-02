using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Город"
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id города
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ "Страна"
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Навигация на родителя
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Навигация на детей
        /// </summary>
        public ICollection<Airport> Airports { get; set; } = new List<Airport>();
        

    }
}
