using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelIT.Models;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingViewController : ControllerBase
    {
        [HttpGet("{year}/{week}")]
        public IEnumerable<BookingView> Get(int year, int week)
        {
            using (var context = new OldSpelarbasenContext())
            {
                var query = context.BookingViews.Where(b => b.Year == year && b.Week == week);
                return query.ToList();

            }
        }
    }
}
