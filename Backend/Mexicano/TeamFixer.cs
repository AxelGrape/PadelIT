using Mexicano.Models;
using System.Text.Json;

namespace Mexicano;

internal class TeamFixer(List<Player> players)
{
    private List<Player> players = players;

    public List<Game> SetGamesAlgorithm()
    {
        if (!VerifyPlayers())
        {
            throw new InvalidOperationException();
        }
        SortPlayersByPoints();

        var games = new List<Game>();

        Team t1 = new();
        Team t2 = new();
        Game game = new();

        for (int i = 0; i < players.Count / 4; i += 4)
        {
            t1.PlayerOne = players[i];
            t1.PlayerTwo = players[i + 3];
            game.TeamOne = t1;

            t2.PlayerOne = players[i + 1];
            t2.PlayerTwo = players[i + 2];
            game.TeamTwo = t2;

            games.Add(game);
        }
        var json = JsonSerializer.Serialize(games);
        return games;
    }

    private void SortPlayersByPoints()
    {
        players = [.. players.OrderBy(p => p.Points)];
    }

    private bool VerifyPlayers()
    {
        if (players.Count % 4 != 0)
            return false;

        return true;
    }
}
