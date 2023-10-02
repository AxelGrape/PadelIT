using System.Security.Cryptography.Pkcs;

namespace PadelIT.Models
{
    public class GameCourt
    {

        public int CourtNumber { get; set; }
        public GameTeam? Team1 { get; set; }
        public GameTeam? Team2 { get; set; }

        public GameCourt(int courtNumber)
        {
            CourtNumber = courtNumber;
        }

        public void SetPlayersT1(GamePlayer player1, GamePlayer player2)
        {
            Team1 = new GameTeam(player1, player2);
        }
        public void SetPlayersT2(GamePlayer player3, GamePlayer player4)
        {
            Team2 = new GameTeam(player3, player4);
        }
    }
}
