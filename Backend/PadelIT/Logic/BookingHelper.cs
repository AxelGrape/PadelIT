using Microsoft.AspNetCore.Mvc;
using PadelIT.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

namespace PadelIT.Logic
{
    public class BookingHelper
    {

        private readonly SpelarbasenContext _context;

        public BookingHelper()
        {
            _context = new SpelarbasenContext();
        }

        private bool VerifyPlayerId(int playerid)
        {
            return  _context.Players.Find(playerid) != null;
        }

        private bool VerifyIfBookingExist(int playerid, int week, int year)
        {
            return _context.Bookings.Where(b => b.PlayerId == playerid && b.Week == week && b.Year == year).Any();
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

                _context.Bookings.Add(new Booking()
                {
                    Year = year,
                    Week = week,
                    PlayerId = playerid,
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }



    }
}
