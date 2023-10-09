using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PadelIT.Logic;
using PadelIT.Database;
using System.Data;
using PadelIT.Database.Models;
using PadelIT.Utilities;
using System.Net;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingHelper _bookingHelper;
        private readonly SpelarbasenContext _context;
        public BookingsController(SpelarbasenContext dbContext, BookingHelper bookingHelper)
        {
            _context = dbContext;
            _bookingHelper = bookingHelper;
        }

        
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            List<Booking> Bookings = _bookingHelper.GetBookings();
            return Ok(Bookings);
        }

        [HttpGet("{name}")]
        public IActionResult GetPlayersBookings(string name)
        {
            try
            {
                List<Booking> playerBookings = _bookingHelper.GetPlayerBookings(name);
                return Ok(playerBookings);
            }
            catch(PlayerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost("{name}/{year}/{week}")]
        public async Task<IActionResult> Post(string name, int year, int week)
        {
            try
            {
                Booking newBooking = await _bookingHelper.AddBooking(name, week, year);
                return Ok(newBooking);
            }
            catch (PlayerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
