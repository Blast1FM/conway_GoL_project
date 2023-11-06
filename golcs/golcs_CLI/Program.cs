using golcs.Renderer;
using golcs.World;

namespace golcs_CLI;

class Program
{
    static int Get_int_from_console()
    {
        if(int.TryParse(Console.ReadLine(), out int number)) return number;
        else return -1; 
    }
    static int Main_menu(int commandID)
    {
        System.Console.WriteLine
        (
            @"1.Start new game
            2.Load megasave
            3.View scoreboard
            0.Exit"
        );
        return Get_int_from_console();
    }
    static void Main(string[] args)
    {
        GameState gameState = new("Blast", 16);

        Renderer.Display_grid(ref gameState.current_grid);
    }
}
