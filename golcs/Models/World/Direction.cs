namespace golcs.Models.World;
public class Direction
{
    public static readonly (int row, int column)[] directions = 
    {
        (1,-1), (1,0),(1,1),(0,-1),(0,1),(-1,-1),(-1,0),(-1,1)
    };
}
