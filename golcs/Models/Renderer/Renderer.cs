namespace golcs.Models.Renderer;
using golcs.Models.World;

public static class Renderer
{
    private static readonly int int_black = System.BitConverter.ToInt32
    (
        new byte[]{ (byte)255, (byte)255, (byte)255, (byte)255 }
    );
    private static readonly int int_white = System.BitConverter.ToInt32
    (
        new byte[]{ (byte)0, (byte)0, (byte)0, (byte)255 }
    );

    public static int[,] Convert_grid_to_2D_int(Grid grid)
    {
        (int grid_width, int grid_height) = grid.dimensions;
        int bmap_width = grid_width * 4;
        int bmap_height = grid_height * 4;
        int stride = bmap_width * 4;
        int[,] integers = new int[bmap_width,bmap_height];

        for (int x = 0; x < grid_width; ++x)
        {
            for (int y = 0; y < grid_height; ++y)
            {
                //Could be prettier - couldn't be bothered to make it so
                //Populate the integers array with appropriate colours
                if (grid.cell_list[x][y].IsAlive())
                {
                    foreach (var (row, column) in Offsets.render_pixel_offsets)
                    {
                        integers[x*4+column,y*4+row] = int_black;
                    }
                } else if(!grid.cell_list[x][y].IsAlive())
                {
                    foreach (var (row, column) in Offsets.render_pixel_offsets)
                    {
                        integers[x*4+column,y*4+row] = int_white;
                    }
                }
            }
        }
        return integers;

    }
}
