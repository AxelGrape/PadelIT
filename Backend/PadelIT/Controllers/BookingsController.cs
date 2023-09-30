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

        [HttpPost("{name}/{year}/{week}")]
        public async Task<IActionResult> Post(String name, int year, int week)
        {
            try
            {
                bool success = await _bookingHelper.AddBooking(name, week, year);
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
