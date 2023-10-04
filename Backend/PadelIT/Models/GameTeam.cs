namespace PadelIT.Models
{
    public class GameTeam
    {
        public List<GamePlayer> Players { get; set; } = new List<GamePlayer>();
        public int CurrentScore { get; set; }
        public int CurrentCourt { get; set; }

        public GameTeam(GamePlayer player1, GamePlayer player2)
        {
            Players.Add(player1);
            Players.Add(player2);
        }
    }
}
