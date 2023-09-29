using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelIT.Models;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            using (var context = new SpelarbasenContext())
            {
                return context.Bookings.ToList();
            }
        }

        [HttpPut("{playerid}/{year}/{week}")]
        public IEnumerable<Booking> Put(int playerid, int year, int week)
        {
            using (var context = new SpelarbasenContext())
            {

                var player = context.Players.Find(playerid);
                if(player == null) { return Enumerable.Empty<Booking>(); }

                Booking booking = new Booking();    
                booking.Year = year;
                booking.Week = week;    
                booking.PlayerId = playerid;
                context.Bookings.Add(booking);  
                context.SaveChanges();
                return context.Bookings.ToList();
            }
        }
    }
   
}
