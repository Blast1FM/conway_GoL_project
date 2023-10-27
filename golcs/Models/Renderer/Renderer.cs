namespace golcs.Models.Renderer;

using System;
using System.Drawing;
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

    public static Bitmap Convert_grid_to_2D_int_and_bitmap(Grid grid)
    {
        (int grid_width, int grid_height) = grid.dimensions;
        //Each cell is represented by 4 pixels - harcoded for now.
        int bmap_width = grid_width * 4;
        int bmap_height = grid_height * 4;
        //Stride has to be width * 4
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

        unsafe
        {
            fixed (int* intPtr = &integers[0,0])
            {
                //Well shit, only works on windows :(
                Bitmap bitmap = new(bmap_width, bmap_height, stride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, new IntPtr(intPtr));
                return bitmap;
            }
        }

        
    }
}
