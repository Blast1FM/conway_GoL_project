namespace golcs.UI;

public class Menu
{
    private int Selected_index;
    private string[] Options;
    private string Prompt;

    public Menu(string[] options, string prompt="Welcome to the game")
    {
        Prompt = prompt;
        Options = options;
        Selected_index = 0;
    }

    private void DisplayOptions()
    {
        System.Console.WriteLine(Prompt);

        for (int i = 0; i < Options.Length; i++)
        {
            string current_option = Options[i];
            string prefix;

            if(i == Selected_index)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            } else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            System.Console.WriteLine($"{prefix} << {current_option} >>");
        }

        Console.ResetColor();
    }

    public int Run()
    {
        ConsoleKey key_pressed;
        do
        {
            Console.Clear();
            DisplayOptions();

            ConsoleKeyInfo key_info = Console.ReadKey(true);
            key_pressed = key_info.Key;

            if(key_pressed == ConsoleKey.DownArrow)
            {
                Selected_index++;
                if(Selected_index >= Options.Length)
                {
                    Selected_index = 0;
                }

            }else if(key_pressed == ConsoleKey.UpArrow)
            {
                Selected_index--;
                if(Selected_index < 0)
                {
                    Selected_index = Options.Length-1;
                }
            }
        } while(key_pressed!=ConsoleKey.Enter);

        return Selected_index;
    }
}
