using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PlayersController : ControllerBase
    {
        private readonly SpelarbasenContext _dbContext;
        public PlayersController(SpelarbasenContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        [HttpGet]
        public IEnumerable<Player> Get()
        {

            return _dbContext.Players.ToList();

        }

        [HttpPut("{name}")]
        public async Task<IEnumerable<Player>> Put(String name)
        {
            Player player = new Player();
            player.Name = name;
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
            return _dbContext.Players.ToList();
        }
    }

}
