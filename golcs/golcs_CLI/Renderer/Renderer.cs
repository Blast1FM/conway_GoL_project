using golcs.World;

namespace golcs.Renderer;

public static class Renderer
{
    public static void Display_grid(ref Grid grid)
    {
        System.Console.WriteLine();
        foreach (var row in grid.cell_list)
        {
            foreach (var item in row)
            {
                System.Console.Write(item.String_repr);
            }
            System.Console.WriteLine();
        }
    }

    public static void Display_bottom_bar(string bar)
    {
        System.Console.WriteLine(bar);
    }
}
