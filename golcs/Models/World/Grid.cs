using System.Collections.Generic;

namespace golcs.Models.World;
public class Grid
{
    public (int width, int height) dimensions;

    //beware nullable
    public List<List<Cell>>? cell_list;

    public Grid(int width, int height)
    {
        this.dimensions = (width, height);
    }

    public void Initialise_cell_list_as_dead((int width, int height) grid_dimensions)
    {
        //Pre-initialise the list
        cell_list = new List<List<Cell>>(grid_dimensions.height);
        for (int i=0; i < grid_dimensions.height; i++)
        {
            cell_list.Add(new List<Cell>(grid_dimensions.width));
        }
        //Populate with dead cells
        for (int row = 0; row < grid_dimensions.height; row++)
        {
            for (int column = 0; column < grid_dimensions.width; column++)
            {
                cell_list[row].Add(new Cell(column, row));
            }
        }

    }


}
