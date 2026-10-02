using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Enums
{
    /// <summary>
    /// Статус авиарейса
    /// </summary>
    public enum FlightStatus
    {
        /// <summary>
        /// Рейс запланирован, выполняется оп расписанию
        /// </summary>
        Scheduled = 0,

        /// <summary>
        /// Рейс задержан
        /// </summary>
        Delayed = 1,

        /// <summary>
        /// Рейс уже вылетел
        /// </summary>
        Departed = 2,

        /// <summary>
        /// Рейс отменен
        /// </summary>
        Cancelled = 3
    }
}
