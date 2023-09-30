using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using PadelIT.Database;
using PadelIT.Database.Models;
using PadelIT.Utilities;

namespace PadelIT.Logic
{

    public interface IBookingHelper
    {
        List<Booking> GetBookings();
        List<Booking> GetPlayerBookings(int playerid);
        Task<Booking> AddBooking(int playerid, int week, int year);
    }

    public class BookingHelper : IBookingHelper
    {

        private readonly SpelarbasenContext _dbContext;

        public BookingHelper(SpelarbasenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Booking> GetBookings()
        {
            return _dbContext.Bookings.ToList();
        }
        public List<Booking> GetPlayerBookings(int playerid)
        {
            //var playerName = GetPlayerName(playerid);
            if(!IsPlayerRegistered(playerid))
                throw new PlayerNotFoundException();
            return _dbContext.Bookings.Where(b => b.PlayerId == playerid).ToList();
        }

        public async Task<Booking> AddBooking(int playerid, int week, int year)
        {
            try
            {
                if (!IsPlayerRegistered(playerid))
                {
                    throw new PlayerNotFoundException();
                }
                if (IsBookingAlreadyBooked(playerid, week, year))
                {
                    throw new CustomException("Player already booked at that time");
                }

                Booking booking = new Booking()
                {
                    Year = year,
                    Week = week,
                    PlayerId = playerid,
                };
                _dbContext.Bookings.Add(booking);

                await _dbContext.SaveChangesAsync();

                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        private bool IsPlayerRegistered(int playerid)
        {
            bool playerExists = _dbContext.Players.Find(playerid) != null;
            return playerExists;
        }

        private bool IsBookingAlreadyBooked(int playerid, int week, int year)
        {
            var bookingExists = _dbContext.Bookings.FirstOrDefault(b => b.PlayerId == playerid && b.Week == week && b.Year == year) != null;
            return bookingExists;
        }
        private string? GetPlayerName(int playerid) => _dbContext.Players.Find(playerid)?.Name;

    }
}
