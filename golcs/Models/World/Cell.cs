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

    public void Kill()
    {
        cell_state = Cell_State.Dead;
        living_neighbour_count = 0;
    }

    public void Revive()
    {
        cell_state = Cell_State.Alive;
        living_neighbour_count = 0;
    }
    
    public bool IsAlive()
    {
        if (cell_state == Cell_State.Dead) return false;
        if (cell_state == Cell_State.Alive) return true;
        throw new System.Exception("Life check fucked up");
    }
}