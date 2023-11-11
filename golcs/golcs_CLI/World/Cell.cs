using golcs.World.Enums;

namespace golcs.World;
[Serializable]
public class Cell 
{
    public (int x, int y) Coords {get;}

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
        Coords = (column, row);
        cell_state = Cell_State.Dead;
        living_neighbour_count = 0;
    }

    public bool Kill()
    {   
        if(cell_state == Cell_State.Dead)
        {
            living_neighbour_count = 0;
            return false;
        }
        cell_state = Cell_State.Dead;
        living_neighbour_count = 0;
        return true;
    }

    public bool Revive()
    {
        if(cell_state == Cell_State.Alive)
        {
            living_neighbour_count = 0;
            return false;
        };
        cell_state = Cell_State.Alive;
        living_neighbour_count = 0;
        return true;
    }

    public void Toggle_life_state()
    {
        if(IsAlive()) Kill(); else Revive();
    }
    
    public bool IsAlive()
    {
        if (cell_state == Cell_State.Dead) return false;
        if (cell_state == Cell_State.Alive) return true;
        throw new System.Exception("Life check fucked up");
    }
}