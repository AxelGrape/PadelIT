using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelIT.Database;
using PadelIT.Database.Models;
using PadelIT.Logic;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingViewController : ControllerBase
    {

        private BookingHelper _bookingHelper;
        public BookingViewController( BookingHelper bookingHelper)
        {
            _bookingHelper = bookingHelper;
        }
        [HttpGet("{year}/{week}")]
        public Task<IEnumerable<BookingView>> Get(int year, int week)
        {
            return _bookingHelper.RetrieveBookings(year, week);
        }
    }
}
