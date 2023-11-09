using golcs.Infrastructure;
using golcs.UI;
using golcs.World;

namespace golcs.Game;

public class Game
{
    string? save_dir;
    List<GameState>? megasave;
    string current_save_path;
    public Game()
    {
        Initialise_save_dir();
    }
    public void Start()
    {
        Run_init_menu();
        Run_main_menu();
    }

    //Create save folder if doesn't exist
    private void Initialise_save_dir()
    {
        string cwd = Directory.GetCurrentDirectory();
        var save_dir = Directory.EnumerateDirectories(cwd, "*golcs_saves");
        if(save_dir.Any())
        {
            this.save_dir = save_dir.First();
        } else
        {
            string save_dir_path = Path.Combine(cwd,"golcs_saves");
            //TODO handle exceptions
            Directory.CreateDirectory(save_dir_path);
            this.save_dir = save_dir_path;
        }
    }

    private void Run_init_menu()
    {
        string prompt = @"
 ██████  ██████  ███    ██ ██     ██  █████  ██    ██ ███████      ██████   █████  ███    ███ ███████      ██████  ███████     ██      ██ ███████ ███████ 
██      ██    ██ ████   ██ ██     ██ ██   ██  ██  ██  ██          ██       ██   ██ ████  ████ ██          ██    ██ ██          ██      ██ ██      ██      
██      ██    ██ ██ ██  ██ ██  █  ██ ███████   ████   ███████     ██   ███ ███████ ██ ████ ██ █████       ██    ██ █████       ██      ██ █████   █████   
██      ██    ██ ██  ██ ██ ██ ███ ██ ██   ██    ██         ██     ██    ██ ██   ██ ██  ██  ██ ██          ██    ██ ██          ██      ██ ██      ██      
 ██████  ██████  ██   ████  ███ ███  ██   ██    ██    ███████      ██████  ██   ██ ██      ██ ███████      ██████  ██          ███████ ██ ██      ███████                                                                                                                                                                                                                                                                                                       
";
        string[] options = {"Load profile","New profile","Exit"};

        Menu init_menu = new(options, prompt);
        int cmd_id = init_menu.Run();
        switch(cmd_id)
        {
            case 0:
                if(Load_megasave()==false)
                {
                    Run_init_menu();
                };
                break;
            case 1:
                Create_new_megasave();
                break;
            case 2:
                Exit_game();
                break;
        }
    }
    private void Run_main_menu()
    {
        string prompt = $"Current profile: {current_save_path}";
        string[] options = {"Load game","New game","View scoreboard","Exit"};
        Menu menu = new(options, prompt);
        int cmd_id = menu.Run();
        switch (cmd_id)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                Exit_game();
                break;
        }
    }
    private void Run_load_megasave_menu(string[] megasaves)
    {
        string prompt = "Which megasave would you like to load?";
        Menu menu = new(megasaves, prompt);
        int cmd_id = menu.Run();
        current_save_path = megasaves[cmd_id];
        //TODO edge case handling?
        megasave = Serialiser.Deserialise_savelist_from_file(current_save_path);
    }
    private void Create_new_megasave()
    {
        Console.Clear();
        System.Console.WriteLine("Enter profile name");
        while(true)
        {   //input can be done in a separate helper method but whatever
            string? input = Console.ReadLine();
            if(String.IsNullOrEmpty(input))
            {
                System.Console.WriteLine("Profile name can't be empty");
            } else 
            {
                megasave = new();
                current_save_path = Path.Combine(save_dir, input)+".golcs";
                //TODO handle filenames same as existing saves
                break;
            }
        }
    }
    private bool Load_megasave()
    {
        var megasaves = Directory.GetFiles(save_dir, "*.golcs");
        if(megasaves.Any())
        {
            Run_load_megasave_menu(megasaves);
            return true;
        } else
        {
            System.Console.WriteLine("No profiles found! Press any key to return to menu.");
            Console.ReadKey(true);
            return false;
        }
    }
    private void Exit_game()
    {   
        Console.Clear();
        System.Console.WriteLine("Thanks for playing!");
        Environment.Exit(0);
    }
}
