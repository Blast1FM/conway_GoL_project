using golcs.Game;
using golcs.Renderer;
using golcs.World;

namespace golcs_CLI;

class Program
{
    static void Main(string[] args)
    {
        Game game = new();
        game.Run();
    }
}
