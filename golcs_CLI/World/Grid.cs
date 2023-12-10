namespace golcs.World;

[Serializable]
public class Grid
{
    public (int width, int height) dimensions;

    //beware nullable
    public List<List<Cell>> cell_list;

    public Grid(int width, int height)
    {
        dimensions = (width, height);
        cell_list = new List<List<Cell>>(dimensions.height);
        Initialise_cell_list_as_dead();
    }

    //Copy constructor for the state controller
    public Grid(Grid other)
    {
        this.dimensions = other.dimensions;
        this.cell_list = other.cell_list;
    }
    //Quick hack because im stupid
    public int Count_living_cells()
    {
        int living_cell_count = 0;
        if(cell_list==null) throw new Exception("Grid doesnt exist");
        foreach (var item in cell_list)
        {
            foreach (var cell in item)
            {
                if (cell.IsAlive()) living_cell_count++;
            }
        }

        return living_cell_count;
    }

    public void Initialise_cell_list_as_dead()
    {
        for (int i=0; i < dimensions.height; i++)
        {
            cell_list.Add(new List<Cell>(dimensions.width));
        }
        //Populate with dead cells
        for (int row = 0; row < dimensions.height; row++)
        {
            for (int column = 0; column < dimensions.width; column++)
            {
                cell_list[row].Add(new Cell(column, row));
            }
        }
    }
}
