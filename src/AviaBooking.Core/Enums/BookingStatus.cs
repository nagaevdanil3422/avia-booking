using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Enums
{
    /// <summary>
    /// Статус бронирования
    /// </summary>
    public enum BookingStatus
    {
        /// <summary>
        /// Бронирование создано, но не оплачено
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Бронирование подтверждено(оплачено)
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Бронирование отменено.
        /// </summary>
        Cancelled = 2
    }
}
