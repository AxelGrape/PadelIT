using PadelIT.Database.Models;

namespace PadelIT.Models
{

    public class GamePlayer : Player
    {
        public int CurrentScore { get; set; }
        public int CurrentCourt { get; set; }

    }
}
