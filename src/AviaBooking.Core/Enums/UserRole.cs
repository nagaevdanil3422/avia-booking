using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Core.Enums
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Обычный зарегистрированный пользователь
        /// </summary>
        User = 0,
        /// <summary>
        /// Администратор системы
        /// </summary>
        Admin = 1
    }
}
