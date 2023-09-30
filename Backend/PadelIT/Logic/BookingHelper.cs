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
            return  _dbContext.Players.Find(playerid) != null;
        }

        private bool VerifyIfBookingExist(int playerid, int week, int year)
        {
            return _dbContext.Bookings.Where(b => b.PlayerId == playerid && b.Week == week && b.Year == year).Any();
        }

        public async Task<bool> AddBooking(int playerid, int week, int year)
        {
            try
            {
                if (!VerifyPlayerId(playerid))
                {
                    return false;
                }

                if (VerifyIfBookingExist(playerid, week, year))
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
