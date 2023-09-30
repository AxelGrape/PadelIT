using Microsoft.AspNetCore.Mvc;
using PadelIT.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using PadelIT.Database;

namespace PadelIT.Logic
{
    public class BookingHelper
    {

        private readonly OldSpelarbasenContext _context;
        private readonly SpelarbasenContext _dbContext;

        public BookingHelper(SpelarbasenContext dbContext)
        {
            _context = new OldSpelarbasenContext();
            _dbContext = dbContext;
        }

        private bool VerifyPlayerId(int playerid)
        {
            bool playerExists = _context.Players.Find(playerid) != null;
            return playerExists;
        }

        private bool IsAlreadyBooked(int playerid, int week, int year)
        {
            var bookingExists = _dbContext.Bookings.FirstOrDefault(b => b.PlayerId == playerid && b.Week == week && b.Year == year) != null;
            return bookingExists;
        }

        public async Task<bool> AddBooking(int playerid, int week, int year)
        {
            try
            {
                if (!VerifyPlayerId(playerid))
                {
                    return false;
                }

                if (IsAlreadyBooked(playerid, week, year))
                {
                    return false;
                }

                _dbContext.Bookings.Add(new Booking()
                {
                    Year = year,
                    Week = week,
                    PlayerId = playerid,
                });

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
