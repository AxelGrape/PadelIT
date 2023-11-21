using Mexicano.Models;
using System.Text.Json;
namespace Mexicano;
public class Interface
{
    public static string StartNewRound(string players)
    {
        List<Player> playerList = ConvertToPlayerList(players);
        TeamFixer teamFixer = new(playerList);
        List<Game> games = teamFixer.SetGamesAlgorithm();
        return JsonSerializer.Serialize(games);
    }
    private static List<Player> ConvertToPlayerList(string players)
    {
        List<Player>? playerList = JsonSerializer.Deserialize<List<Player>>(players);
        return playerList is null ? throw new Exception() : playerList;
    }
}
.
