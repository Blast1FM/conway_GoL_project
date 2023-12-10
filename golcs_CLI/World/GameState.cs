namespace golcs.World;

[Serializable]
public class GameState
{
    public int generation_count;

    public string player_name;

    public int high_score;

    public int current_live_cells;

    public Grid current_grid;

    public GameState(string playername="Player", int grid_dim=32)
    {
        player_name = playername;
        high_score = 0;
        generation_count = 0;
        current_grid = new Grid(grid_dim,grid_dim);
    }

    //public GameState(string playername) : this()
    //{
    //      player_name = playername;
    //}
}
