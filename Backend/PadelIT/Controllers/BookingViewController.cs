using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelIT.Logic;
using PadelIT.Models;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingViewController : ControllerBase
    {

        private BookingHelper _bookingHelper = new BookingHelper();

        [HttpGet("{year}/{week}")]
        public Task<IEnumerable<BookingView>> Get(int year, int week)
        {
            return _bookingHelper.RetrieveBookings(year, week);
        }
    }
}
