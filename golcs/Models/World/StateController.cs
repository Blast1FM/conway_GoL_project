namespace golcs.Models.World;
public static class StateController
{
    public static void Set_living_neighbour_counters(ref GameState game_state)
    {
        (int width, int height) = game_state.current_grid.dimensions;
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                Set_living_neighbours_for_cell(ref game_state.current_grid, row, column);
            }
        }
    }

    //point of failure
    public static void Set_living_neighbours_for_cell(ref Grid grid, int cell_row, int cell_column)
    {
        //This would've been used for a more elegant boundary check but oh well
        //(int width, int height) = grid.dimensions;
        foreach (var (row, column) in Offsets.life_check_offsets)
        {
            try
            {
                if(grid.cell_list[cell_row+row][cell_column+column].IsAlive())
                {
                    grid.cell_list[cell_row][cell_column].living_neighbour_count++;
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
                Modify_cell_state_for_cell(ref game_state.current_grid, row, column);
            }
        }
        game_state.generation_count++;
    }

    //point of failure
    public static void Modify_cell_state_for_cell(ref Grid grid, int cell_row, int cell_column)
    {   
        var current_cell = grid.cell_list[cell_row][cell_column];
        if(current_cell.IsAlive())
        {
            if(current_cell.living_neighbour_count < 2 || current_cell.living_neighbour_count > 3)
            {
                current_cell.Kill();
            } else current_cell.Revive();
        } else if (current_cell.living_neighbour_count == 3) current_cell.Revive(); else current_cell.Kill();
    }
}
