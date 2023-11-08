using golcs.UI;
using System.IO;

namespace golcs.Game;

public class Game
{
    
    public void Start()
    {
        Initialise_save_dir();
        Run_main_menu();
    }

    //Create save folder if doesn't exist
    //If it does, populate with filenames matching pattern
    //TODO implement
    private void Initialise_save_dir()
    {
        
        string cwd = Directory.GetCurrentDirectory();
        if(Directory.EnumerateDirectories(cwd,"*golcs_saves").Any())
        {
            throw new NotImplementedException();
        } else
        {
            throw new NotImplementedException();
        }
        
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
        string[] options = {"Load megasave","New megasave","Exit"};

        Menu init_menu = new(options, prompt);
        int cmd_id = init_menu.Run();
        switch(cmd_id)
        {
            case 0:
                Menu_load_megasave();
                break;
            case 1:
                break;
            case 2:
                Menu_exit_game();
                break;
        }
    }

    private void Menu_exit_game()
    {   
        Console.Clear();
        System.Console.WriteLine("Thanks for playing!");
        Environment.Exit(0);
    }

    private void Menu_load_megasave()
    {

    }
}
