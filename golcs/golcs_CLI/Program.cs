using golcs.Renderer;
using golcs.World;

namespace golcs_CLI;

class Program
{
    static void Main(string[] args)
    {
        GameState gameState = new("Blast", 16);
        Renderer.Display_game(ref gameState);
    }
}
