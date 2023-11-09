using golcs.Infrastructure;
using golcs.UI;
using golcs.World;

namespace golcs.Game;

public class Game
{
    string? save_dir;
    SaveController save_controller;
    public Game()
    {
        Initialise_save_dir();
    }
    public void Run()
    {
        Run_init_menu();
        
        GameState? current_game;            //= null;, but should be null by default
        do
        {
            current_game = Run_main_menu();
        }while(current_game==null);

        Run_game_loop(current_game);
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
    private GameState? Run_main_menu()
    {
        string prompt = $"Current profile: {save_controller.profile_name}";
        string[] options = {"Load game","New game","View scoreboard","Exit"};
        Menu menu = new(options, prompt);
        int cmd_id = menu.Run();
        switch (cmd_id)
        {
            case 0:
                //TODO Load game, return gamestate
                //Use menus like with profiles
                return null;
            case 1:
                GameState game = Create_new_game();
                save_controller.Save_game(game);
                return game;
            case 2:
                View_scoreboard();
                return null;
            case 3:
                Exit_game();
                return null;
            default:
                return null;
        }
    }

    //TODO IMPORTANT IMPORTANT IMPORTANT have a check for gen 0, which leads to calling the setup game method first
    private void Run_game_loop(GameState game)
    {
        
    }

    private void View_scoreboard()
    {
        System.Console.WriteLine("WIP. Press any key to return to main menu");
        Console.ReadKey(true);
    }

    private GameState Create_new_game()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the player name");
        string playername = Get_string_input();

        return new GameState(playername);

    }
    private void Run_load_megasave_menu(string[] megasaves)
    {
        string prompt = "Which profile would you like to load?";
        Menu menu = new(megasaves, prompt);
        int cmd_id = menu.Run();
        //Could be done with properties lol
        save_controller.profile_save_path = megasaves[cmd_id];
        //TODO edge case handling?
        if(!save_controller.Load_megasave(save_controller.profile_save_path))
        {
            throw new System.Exception("Failed to load profile");
        }
    }
    private void Create_new_megasave()
    {
        Console.Clear();
        System.Console.WriteLine("Enter profile name");
        string input = Get_string_input();
        string save_path = Path.Combine(save_dir, input)+".golcs";
        save_controller = new SaveController(save_path, input);
        //TODO handle filenames same as existing saves
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

    private string Get_string_input()
    {
        while(true)
        {
            string? input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                System.Console.WriteLine("Invalid input, try again");
            } else return input;   
        }
    }

    private int Get_int_input()
    {
        while(true)
        {
            if(int.TryParse(Console.ReadLine(), out int number)) return number;
            else System.Console.WriteLine("Invalid input, try again");
        }
    }
}
