﻿using Models;

namespace Intefaces.Repositories
{
    public interface IBookingRepository
    {
        public void CreateBooking(Booking booking);
        public void ReserveSeatsForBooking(Booking booking, string[] seats, AppUser? user);
        Task<IList<string>> GetReservedSeatsForShow(int showId, DateTime dateOfShow);
        Task<bool> CheckIfReserved(int showId, DateTime dateOfShow, AppUser? user);
        Task<IReadOnlyList<Booking>> GetBookingsForUserAync(AppUser? user);
        Task<bool> Complete();
        Task SetAppearForBooking(int bookingId);
        Task<IList<Booking>> GetBookingsForShowAndDate(int showId, DateTime dateGiven);
        Task<IList<Booking>> GetBookingsForUserNotAppearedAync(AppUser user);
        Task<IList<Booking>> GetBookingsForUserAsync(AppUser? user);
    }
}
