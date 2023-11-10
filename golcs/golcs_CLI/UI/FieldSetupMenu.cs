using golcs.World;
namespace golcs.UI;

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

    }

    //TODO implement
    public (int x, int y) Run()
    {
        
        return(0,0);
    }

}
