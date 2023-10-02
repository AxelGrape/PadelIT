using Microsoft.EntityFrameworkCore;
using PadelIT.Database;
using PadelIT.Database.Models;
using PadelIT.Utilities;
using System;
using System.Globalization;

namespace PadelIT.Logic
{
    public interface IBookingHelper
    {
        List<Booking> GetBookings();
        List<Booking> GetPlayerBookings(string name);
        Task<Booking> AddBooking(string name, int week, int year);
    }

    public class BookingHelper : IBookingHelper
    {

        private readonly SpelarbasenContext _context;

        public BookingHelper(SpelarbasenContext dbContext)
        {
            _context = dbContext;
        }

        // Methods for creating new bookings

        private int AddPlayer(string name)
        {
            _context.Players.Add(new Player() { Name = name });
            _context.SaveChanges();
            return _context.Players.Max(p => p.PlayerId);
        }

        private bool PlayerExists(string name)
        {
            bool playerExists = _context.Players.FirstOrDefault(x => x.Name == name) != null;
            return playerExists;
        }
        private Player? GetPlayerIfExists(string name)
        {
            var playerExists = _context.Players.FirstOrDefault(x => x.Name == name);
            return playerExists;
        }

        private string? GetPlayerName(int id) => _context.Players.Find(id)?.Name;

        // Returns player id that matches name
        // if no id matches name a new entry is added
        // and the new id is returned
        private int GetOrCreatePlayerId(string name)
        {
            var player = GetPlayerIfExists(name);
            if (player != null)
            {
                return player.PlayerId;    
            }
            else
            {
                return AddPlayer(name);
            }
        }

        private bool BookingExists(int playerid, int week, int year)
        {
            var weekDatetime = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);

            var bookingExists = _context.Bookings.FirstOrDefault(b => b.PlayerId == playerid && b.Datetime.Date == weekDatetime.Date &&b.Datetime.Month == weekDatetime.Month && b.Datetime.Year == year) != null;
            return bookingExists;
        }

        // Creates a new booking 
        // If player name does not exist in
        // database, create a new player and create
        // the booking
        public async Task<Booking> AddBooking(string name, int week, int year)
        {
            try
            {
                int playerId = GetOrCreatePlayerId(name);//Hmmmmm

                if (!PlayerExists(name))
                {
                    throw new PlayerNotFoundException();
                }
                if (BookingExists(playerId, week, year))
                {
                    throw new CustomException("Player already booked at that time");
                }

                Booking booking = new Booking()
                {
                    Datetime = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday),
                    PlayerId = playerId,
                };
                _context.Bookings.Add(booking);

                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Booking> GetPlayerBookings(string name)
        {
            //var playerName = GetPlayerName(playerid);
            if (!PlayerExists(name))
                throw new PlayerNotFoundException();
            int playerId = GetOrCreatePlayerId(name);
            return _context.Bookings.Where(b => b.PlayerId == playerId).ToList();
        }
        public List<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        // Methods for retrieving booked players 
        // for a given week/year

        public async Task<IEnumerable<BookingView>> RetrieveBookings(int year, int week)
        {
            var weekDatetime = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);

            return _context.BookingViews.Where(b => b.Datetime.Year == year && b.Datetime.Month == weekDatetime.Month && b.Datetime.Date == weekDatetime.Date ).ToList();
        }



    }
}
