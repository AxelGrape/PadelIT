using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelIT.Models;

namespace PadelIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            using (var context = new OldSpelarbasenContext())
            {
                return context.Players.ToList();
            }
        }

        [HttpPut("{name}")]
        public IEnumerable<Player> Put(String name)
        {
            using (var context = new OldSpelarbasenContext())
            {
                Player player = new Player();
                player.Name = name;
                context.Players.Add(player);
                context.SaveChanges();
                return context.Players.ToList();
            }
        }
    }
    
}
