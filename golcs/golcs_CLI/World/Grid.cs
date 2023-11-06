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
        Initialise_cell_list_as_dead();
    }

    //Copy constructor for the state controller
    public Grid(Grid other)
    {
        this.dimensions = other.dimensions;
        this.cell_list = other.cell_list;
    }

    public void Initialise_cell_list_as_dead()
    {
        //Pre-initialise the list
        cell_list = new List<List<Cell>>(dimensions.height);
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
