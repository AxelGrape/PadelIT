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

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingViewController : ControllerBase
    {
        SpelarbasenContext _dbContext;
        public BookingViewController(SpelarbasenContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{year}/{week}")]
        public IEnumerable<BookingView> Get(int year, int week)
        {
            var query = _dbContext.BookingViews.Where(b => b.Year == year && b.Week == week);
            return query.ToList();

        }
    }
}
