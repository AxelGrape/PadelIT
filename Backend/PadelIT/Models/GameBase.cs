using PadelIT.Database.Models;

namespace PadelIT.Models
{
    public abstract class GameBase
    {
        private readonly int gameSetting = 14;
        private readonly int p1, p2, p3, p4;
        public List<GamePlayer> Players { get; set; }

        public List<GameCourt> GameCourts { get; set; }

        public GameBase()
        {
            Players = new List<GamePlayer>();
            GameCourts = new List<GameCourt>();
            if (gameSetting == 14)
            {
                p1 = 0; p2 = 3;
                p3 = 1; p4 = 2;
            }
            else if (gameSetting == 13)
            {
                p1 = 0; p2 = 2;
                p3 = 1; p4 = 3;
            }
            else if (gameSetting == 12)
            {
                p1 = 0; p2 = 1;
                p3 = 2; p4 = 3;
            }
        }

        public void AddPlayer(GamePlayer player)
        {
            Players.Add(player);
        }
        public void ResetPlayers()
        {
            foreach (var player in Players)
            {
                player.CurrentScore = 0;
                player.CurrentCourt = 0;
            }
        }
        public void RemoveAllPlayers()
        {
            Players.Clear();
        }
        public void RemoveAllCourts()
        {
            GameCourts.Clear();
        }

        public void ResetTeams()
        {
            GameCourts.ForEach(c => c.ClearTeams());
        }

        public void SetTeams()
        {
            
        }

        private void SavePlayerPoints()
        {
            Players.ForEach(p => p.CurrentScore += GetTeamPoints(p));
        }

        private int GetTeamPoints(GamePlayer player)
        {
            var playerCourt = player.CurrentCourt;
            var team = GameCourts[playerCourt].Teams.Find(t => t.Players.Contains(player));
            if (team != null)
            {
                return team.CurrentScore;
            }
            else
            {
                return 0;
            }
        }

        private void EndRound()
        {
            SavePlayerPoints();
            SortPlayers();
            ResetTeams();
        }
        public void SetCourts(int numberOfCourts)
        {
            for (int i = 0; i < numberOfCourts; i++)
            {
                GameCourts.Add(new GameCourt(i));
            }
        }
        public void StartGame()
        {
            int numberOfCourts = (Players.Count / 4);
            SetCourts(numberOfCourts);
            SetTeams();
        }

        public void UpdateTeamScore(int courtNumber, int teamNumber, int score)
        {
            GameCourts[courtNumber].Teams[teamNumber].CurrentScore = score;
        }

        public void StartNextRound()
        {
            EndRound();
            ResetTeams();
            SetTeams();

        }

        public void StartFinalRound()
        {

        } 
        private void SortPlayers()
        {
            Players = Players.OrderBy(p => p.CurrentScore).ToList();
        }
    }
}
