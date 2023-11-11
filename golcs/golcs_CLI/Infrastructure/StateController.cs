using golcs.World;

namespace golcs.Infrastructure;

/// <summary>
/// Updates game state - GoL logic here.
/// </summary>
public static class StateController
{
    public static void Update_game_state(ref GameState game_state)
    {
        Set_living_neighbour_counters(ref game_state);
        Modify_cell_states(ref game_state);
        game_state.generation_count++;
        if(game_state.current_live_cells>game_state.high_score)
        {
            game_state.high_score = game_state.current_live_cells;
        }
    }

    public static void Set_living_neighbour_counters(ref GameState game_state)
    {
        (int width, int height) = game_state.current_grid.dimensions;
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                Set_living_neighbours_for_cell(ref game_state, row, column);
            }
        }
    }

    //point of failure
    public static void Set_living_neighbours_for_cell(ref GameState gamestate, int cell_row, int cell_column)
    {
        //This would've been used for a more elegant boundary check but oh well
        //(int width, int height) = grid.dimensions;
        foreach (var (row, column) in Offsets.life_check_offsets)
        {
            try
            {
                if(gamestate.current_grid.cell_list[cell_row+row][cell_column+column].IsAlive())
                {
                    gamestate.current_grid.cell_list[cell_row][cell_column].living_neighbour_count++;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }
        }
    }

    public static void Modify_cell_states(ref GameState game_state)
    {
        (int width, int height) = game_state.current_grid.dimensions;
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                Modify_cell_state_for_cell(ref game_state, row, column);
            }
        }
    }

    //Should rewrite cell killing tbh
    public static void Modify_cell_state_for_cell(ref GameState gamestate, int cell_row, int cell_column)
    {   
        var current_cell = gamestate.current_grid.cell_list[cell_row][cell_column];
        if(current_cell.IsAlive())
        {
            if(current_cell.living_neighbour_count < 2 || current_cell.living_neighbour_count > 3)
            {
                if(current_cell.Kill())
                {
                    gamestate.current_live_cells--;
                }
            } else 
            {
                if(current_cell.Revive())
                {
                    gamestate.current_live_cells++;
                } 
            }
        } else if (current_cell.living_neighbour_count == 3)
        {
            if(current_cell.Revive())
            {
                gamestate.current_live_cells++;
            }
        } else 
        {
            if(current_cell.Kill())
            {
                gamestate.current_live_cells--;
            }
        }
    }
}
