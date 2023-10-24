using golcs.Models.World.Enums;

namespace golcs.Models.World;

public class Cell 
{
    public (int, int) Position {get;}

    public Cell_State cell_state;

    public int living_neighbour_count;

    public Cell(int column, int row)
    {
        this.Position = (column, row);
        this.cell_state = Cell_State.Dead;
        this.living_neighbour_count = 0;
    }

}