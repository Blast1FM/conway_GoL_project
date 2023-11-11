using golcs.World;

namespace golcs.Infrastructure;
public static class Hacks
{
    public static List<string> Get_playernames(List<GameState>gamestates)
    {
        List<string> playernames = new();
        foreach (var item in gamestates)
        {
            playernames.Add(item.player_name);
        }
        return playernames;
    }
}
