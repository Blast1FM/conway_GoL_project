namespace golcs.World;
public class Offsets
{
    public static readonly (int row, int column)[] life_check_offsets = 
    {
        (1,-1),(1,0),(1,1),(0,-1),(0,1),(-1,-1),(-1,0),(-1,1)
    };

    public static readonly (int row, int column)[] render_pixel_offsets = 
    {
        (0,0),(0,1),(0,2),(0,3),
        (1,0),(1,1),(1,2),(1,3),
        (2,0),(2,1),(2,2),(2,3),
        (3,0),(3,1),(3,2),(3,3)
    };
}
