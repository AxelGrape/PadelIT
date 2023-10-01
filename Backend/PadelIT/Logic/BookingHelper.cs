using Microsoft.EntityFrameworkCore;
using PadelIT.Database;
using PadelIT.Database.Models;
using PadelIT.Utilities;

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
            bool playerExists = _context.Players.Find(name) != null;
            return playerExists;
        }

        private string? GetPlayerName(int id) => _context.Players.Find(id)?.Name;

        // Returns player id that matches name
        // if no id matches name a new entry is added
        // and the new id is returned
        private int GetPlayerId(string name)
        {
            if (PlayerExists(name))
            {
                return _context.Players.Where(p => p.Name == name).First().PlayerId;    
            }
            else
            {
                return AddPlayer(name);
            }
        }

        private bool BookingExists(int playerid, int week, int year)
        {
            var bookingExists = _context.Bookings.FirstOrDefault(b => b.PlayerId == playerid && b.Week == week && b.Year == year) != null;
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
                int playerId = GetPlayerId(name);//Hmmmmm

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
                    Year = year,
                    Week = week,
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
            int playerId = GetPlayerId(name);
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
            return _context.BookingViews.Where(b => b.Year == year && b.Week == week).ToList();
        }



    }
}
