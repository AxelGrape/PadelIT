using System.Security.Cryptography.Pkcs;

namespace PadelIT.Models
{
    public class GameCourt
    {

        public int CourtNumber { get; set; }
        public List<GameTeam> Teams { get; set; } = new List<GameTeam>();

        public GameCourt(int courtNumber)
        {
            CourtNumber = courtNumber;
        }

        public void SetPlayersT1(GamePlayer player1, GamePlayer player2)
        {
            Teams.Add(new GameTeam(player1, player2));
        }
        public void SetPlayersT2(GamePlayer player3, GamePlayer player4)
        {
            Teams.Add(new GameTeam(player3, player4));
        }
        public void ClearTeams()
        {
            Teams.Clear();
        }


    }
}
