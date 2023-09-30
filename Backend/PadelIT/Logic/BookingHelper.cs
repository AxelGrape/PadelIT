using PadelIT.Models;

namespace PadelIT.Logic
{
    public class BookingHelper
    {

        private readonly SpelarbasenContext _context;

        public BookingHelper()
        {
            _context = new SpelarbasenContext();
        }

        // Methods for creating new bookings

        private int AddPlayer(String name)
        {
            _context.Players.Add(new Player() { Name = name });
            _context.SaveChanges();
            return _context.Players.Max(p => p.PlayerId);
        }

        private bool CheckIfPlayerExist(String name)
        {
            return _context.Players.Where(p => p.Name.Equals(name)).Any();
        }

        private bool VerifyPlayerId(int playerid)
        {
            return _context.Players.Find(playerid) != null;
        }

        // Returns player id that matches name
        // if no id matches name a new entry is added
        // and the new id is returned
        private int GetPlayerId(String name)
        {
            if (CheckIfPlayerExist(name))
            {
                return _context.Players.Where(p => p.Name == name).First().PlayerId;    
            }
            else
            {
                return AddPlayer(name);
            }
        }


        private bool VerifyIfBookingExist(int playerid, int week, int year)
        {
            return _context.Bookings.Where(b => b.PlayerId == playerid && b.Week == week && b.Year == year).Any();
        }

        // Creates a new booking 
        // If player name does not exist in
        // database, create a new player and create
        // the booking
        public async Task<bool> AddBooking(String name, int week, int year)
        {
            try
            {
                int playerId = GetPlayerId(name);
                if (VerifyIfBookingExist(playerId, week, year))
                {
                    return false;
                }

                _context.Bookings.Add(new Booking()
                {
                    Year = year,
                    Week = week,
                    PlayerId = playerId,
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // Methods for retrieving booked players 
        // for a given week/year

        public async Task<IEnumerable<BookingView>> RetrieveBookings(int year, int week)
        {
            return _context.BookingViews.Where(b => b.Year == year && b.Week == week).ToList();
        }

    }
}
