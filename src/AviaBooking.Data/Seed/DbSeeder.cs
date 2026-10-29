using AviaBooking.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaBooking.Data.Seed
{
    /// <summary>
    /// Класс для наполнения базы данных тестовыми данными
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Основной метод наполнения БД
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedAsync(AppDbContext context)
        {
            //Применяем миграции если они не применены, если допустим я открою на другой машине проект 
            await context.Database.MigrateAsync();
            
            //если страны уже есть то ен добавляем их заново
            if (context.Countries.AnyAsync())
            {
                return;
            }


            await SeedCountriesAndCitiesAsync(context);
            await SeedAirportsAsync(context);
            await SeedAirlinesAndAircraftsAsync(context);
            await SeedFareClassesAsync(context);
            await SeedFlightsAsync(context);
            await SeedUsersAsync(context);

            await context.SaveChangesAsync(context);
        }
    }
}
