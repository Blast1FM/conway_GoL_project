using golcs.World;

namespace golcs.Renderer;

public static class Renderer
{
    private static void Display_grid(ref Grid grid)
    {
        foreach (var row in grid.cell_list)
        {
            foreach (var item in row)
            {
                System.Console.Write(item.String_repr);
            }
            System.Console.WriteLine();
        }
    }

    private static void Display_bottom_bar(string bar)
    {
        System.Console.WriteLine(bar);
    }

    private static void Display_game_stats(ref GameState gameState)
    {
        System.Console.WriteLine($"Player name: {gameState.player_name} Generation:{gameState.generation_count} High score:{gameState.high_score} Cells alive:{gameState.current_live_cells}");
    }

    public static void Display_game(ref GameState gameState)
    {
        Console.Clear();
        Display_game_stats(ref gameState);
        Display_grid(ref gameState.current_grid);
        Display_bottom_bar("placeholder");
    }
}
