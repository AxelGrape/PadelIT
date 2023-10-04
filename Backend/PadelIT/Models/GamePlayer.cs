using PadelIT.Database.Models;

namespace PadelIT.Models
{

    public class GamePlayer : Player
    {
        public int CurrentScore { get; set; } = 0;
        public int CurrentCourt { get; set; } = -1;

    }
}
