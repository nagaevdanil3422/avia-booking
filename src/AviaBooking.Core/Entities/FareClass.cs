using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Entities
{
    /// <summary>
    /// Сущность "Класс обслуживания"
    /// </summary>
    public class FareClass
    {
        /// <summary>
        /// Id класса обслуживания
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Economy / Business
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Множитель цены (1.0, 2.5)
        /// </summary>
        public decimal Multiplier {  get; set; }

        /// <summary>
        /// Билеты этого класса
        /// </summary>
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
