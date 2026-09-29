1. Country — Страна
text
Id, Name, IsoCode (2 буквы: RU, US)
2. City — Город
text
Id, Name, CountryId (FK)
3. Airport — Аэропорт
text
Id, IataCode (3 буквы, unique), Name, CityId (FK)
4. Airline — Авиакомпания
text
Id, IataCode (unique), Name, CountryId (FK)
5. Aircraft — Самолёт
text
Id, Model ("Boeing 737-800"), RegistrationNumber (бортовой, unique),
SeatsCount, AirlineId (FK)
6. FareClass — Класс обслуживания
text
Id, Name ("Economy", "Business"), Multiplier (decimal: 1.0, 2.5)
Цена билета = Flight.BasePrice × FareClass.Multiplier

7. Flight — Рейс
text
Id, FlightNumber ("SW1234"), AirlineId (FK), AircraftId (FK),
DepartureAirportId (FK → Airport), ArrivalAirportId (FK → Airport),
DepartureTime, ArrivalTime, BasePrice (decimal), Status (enum)
Две связи с Airport! Это ключевой момент.

8. User — Пользователь
text
Id, Email (unique), PasswordHash, FirstName, LastName,
Role (enum: User/Admin), CreatedAt
9. Booking — Бронирование (PNR)
text
Id, BookingCode (6 символов, unique — как в реальности!),
UserId (FK), CreatedAt, Status (enum: Pending/Confirmed/Cancelled),
TotalPrice (decimal)
10. Ticket — Билет
text
Id, BookingId (FK), FlightId (FK), FareClassId (FK),
PassengerFirstName, PassengerLastName, PassportNumber,
SeatNumber (nullable), Price (decimal — фиксируется при покупке!)
Связи:

text
Country 1──N City 1──N Airport
Country 1──N Airline 1──N Aircraft
Airline 1──N Flight
Aircraft 1──N Flight
Airport 1──N Flight (×2: Departure, Arrival)
Flight 1──N Ticket
FareClass 1──N Ticket
User 1──N Booking 1──N Ticket


Пользовательские сценарии

1. Поиск рейса (гость): заходит на сайт, выбирает откуда лететь, куда, когда, когда обратно, и выибрает кол-во пассажиров и класс обслуживания. Дальше выбор стоит на рейсах по их цене, после выбора нажимает купить, регистрируется и проводит оплату билета 

2. Регистрация и вход: вылезает форма где нужно ввести данные если не зарегистрирован, если зарегистрирован нажимает вход и вводит логин и пароль

3. Бронирование билета (user): Выбирает рейс нажимает купить, выбирает место и оплачивает

4. Просмотр и отмена своих броней (user): просматривает свои брони в личном кабинете может отменить, перенести бронь и тд

5. Управление рейсами (admin): может создать рейс, удалить, изменить(перенести например), просматривать их и тд.