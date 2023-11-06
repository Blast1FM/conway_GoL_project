using golcs.World.Enums;

namespace golcs.World;

public class Cell 
{
    public (int, int) Position {get;}

    public Cell_State cell_state;

    public string String_repr
    {
        get
        {
            if(cell_state == Cell_State.Dead) return "X";
            return "O";
        }
    }

    public int living_neighbour_count;

    public Cell(int column, int row)
    {
        Position = (column, row);
        cell_state = Cell_State.Dead;
        living_neighbour_count = 0;
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