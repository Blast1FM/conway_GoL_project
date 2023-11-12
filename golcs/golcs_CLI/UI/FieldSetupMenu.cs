using golcs.World;
namespace golcs.UI;

/// <summary>
/// Menu used to setup the initial gamestate
/// </summary>
public class FieldSetupMenu
{
    private string Prompt;
    private Grid Game_field;
    private (int x, int y) Selected_index;

    public FieldSetupMenu(Grid field, string prompt="Default field setup prompt")
    {
        Game_field = field;
        Prompt = prompt;
        Selected_index = (0,0);
    }

    //TODO implement
    private void DisplayOptions()
    {
        System.Console.WriteLine(Prompt);
        if(Game_field==null) return;
        for (int row = 0; row < Game_field.cell_list.Count; row++)
        {
            for(int column = 0; column < Game_field.cell_list[row].Count; column++)
            {
                string current_cell = Game_field.cell_list[row][column].String_repr;
                if((column, row) == Selected_index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                System.Console.Write(current_cell);
                Console.ResetColor();
            }
            System.Console.WriteLine();
        }
    }

    //TODO i am lazy
    public int Compare_coords_to_dimensions(int dim, (int x, int y) coords)
    {
        return 0;
    }

    //TODO implement
    public Grid Run()
    {
        ConsoleKey key_pressed;
        do
        {
            Console.Clear();
            DisplayOptions();

            ConsoleKeyInfo key_info = Console.ReadKey(true);
            key_pressed = key_info.Key;

            switch (key_pressed)
            {
                case ConsoleKey.DownArrow:
                    Selected_index.y++;
                    if(Selected_index.y>=Game_field.dimensions.height)
                    {
                        Selected_index.y = 0;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    Selected_index.y--;
                    if(Selected_index.y<0)
                    {
                        Selected_index.y = Game_field.dimensions.height-1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    Selected_index.x--;
                    if(Selected_index.x<0)
                    {
                        Selected_index.x = Game_field.dimensions.width-1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    Selected_index.x++;
                    if(Selected_index.x>=Game_field.dimensions.width)
                    {
                        Selected_index.x = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    Game_field.cell_list[Selected_index.y][Selected_index.x].Toggle_life_state();
                    break;
            }
            
        } while(key_pressed!=ConsoleKey.Escape);

        return Game_field;
    }
}
