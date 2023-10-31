using System;
namespace golcs.Models.World;

[Serializable]
public class GameState
{
    public int generation_count;

    public string player_name;

    public int high_score;

    public Grid current_grid;

    public GameState()
    {
        player_name = "Player";
        high_score = 0;
        generation_count = 0;
        current_grid = new Grid(128,128);
    }

    public GameState(string playername) : this()
    {
        player_name = playername;
    }
}
