using golcs.Game;
using golcs.Renderer;
using golcs.World;

namespace golcs_CLI;
/// <summary>
/// App entry point
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        Game game = new();
        game.Run();
    }
}
