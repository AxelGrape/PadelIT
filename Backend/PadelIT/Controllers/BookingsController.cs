using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PadelIT.Models;
using PadelIT.Logic;
using PadelIT.Database;
using System.Data;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private BookingHelper _bookingHelper;
        private readonly SpelarbasenContext _dbContext;
        public BookingsController(SpelarbasenContext dbContext, BookingHelper bookingHelper)
        {
            _dbContext = dbContext;
            _bookingHelper = bookingHelper;
        }

        
        [HttpGet]
        public List<Booking> Get()
        {

            var entries = _dbContext.Bookings.ToList();
            return entries;
        }

        [HttpPost("{playerid}/{year}/{week}")]
        public async Task<IActionResult> Post(int playerid, int year, int week)
        {
            try
            {
                bool success = await _bookingHelper.AddBooking(playerid, week, year);
                if (!success)
                {
                    return NotFound();
                }
                return Ok(success);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
