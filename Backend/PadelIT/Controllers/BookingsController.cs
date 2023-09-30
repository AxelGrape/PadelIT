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

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private BookingHelper _bookingHelper = new BookingHelper();

        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            using (var context = new SpelarbasenContext())
            {
                return context.Bookings.ToList();
            }
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
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            
        }
    }
   
}
