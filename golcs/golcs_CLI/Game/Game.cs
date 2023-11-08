using golcs.UI;

namespace golcs.Game;

public class Game
{
    public void Start()
    {
        Run_main_menu();
    }

    private void Run_main_menu()
    {
        string prompt = @"
 ██████  ██████  ███    ██ ██     ██  █████  ██    ██ ███████      ██████   █████  ███    ███ ███████      ██████  ███████     ██      ██ ███████ ███████ 
██      ██    ██ ████   ██ ██     ██ ██   ██  ██  ██  ██          ██       ██   ██ ████  ████ ██          ██    ██ ██          ██      ██ ██      ██      
██      ██    ██ ██ ██  ██ ██  █  ██ ███████   ████   ███████     ██   ███ ███████ ██ ████ ██ █████       ██    ██ █████       ██      ██ █████   █████   
██      ██    ██ ██  ██ ██ ██ ███ ██ ██   ██    ██         ██     ██    ██ ██   ██ ██  ██  ██ ██          ██    ██ ██          ██      ██ ██      ██      
 ██████  ██████  ██   ████  ███ ███  ██   ██    ██    ███████      ██████  ██   ██ ██      ██ ███████      ██████  ██          ███████ ██ ██      ███████                                                                                                                                                                                                                                                                                                       
";
        string[] options = {"Load megasave", "Exit"};

        Menu menu = new(options, prompt);
        int cmd_id = menu.Run();

        //TODO draw out options to make it easier to implement
        switch(cmd_id)
        {
            case 0:
                break;
            case 1:
                Exit_game();
                break;
        }
    }

    private void Exit_game()
    {   
        Console.Clear();
        System.Console.WriteLine("Thanks for playing!");
        Environment.Exit(0);
    }
}
