namespace PadelIT.Models
{
    public class GameTeam
    {
        public GamePlayer Player1 { get; set; }
        public GamePlayer Player2 { get; set; }
        public int CurrentScore { get; set; }
        public int CurrentCourt { get; set; }

        public GameTeam(GamePlayer player1, GamePlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
