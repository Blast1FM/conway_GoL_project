using golcs.Infrastructure;
using golcs.UI;
using golcs.World;
using golcs.Renderer;
using System.Net.Mail;

namespace golcs.Game;
/// <summary>
/// Main game driver code
/// </summary>
public class Game
{
    string save_dir;
    SaveController save_controller;
    // Is not null in Initialise_Save_dir, save dir too
    public Game()
    {
        Initialise_save_dir();
    }
    public void Run()
    {
        Run_init_menu();
        
        while(true)
        {
            GameState? current_game;            
            // = null;, but should be null by default
            do
            {
                current_game = Run_main_menu();
            }while(current_game==null);

            Run_game_loop(ref current_game);
            
            if(save_controller.Save_savelist_to_file(save_controller.profile_save_path))
            {
                System.Console.WriteLine("Game saved successfully. Press any key to continue");
                Console.ReadKey(true);
            } else System.Console.WriteLine("Something went wrong when saving.");
        }
    }

    /// <summary>
    /// Create save folder if doesn't exist.
    /// </summary>
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
        const string prompt = @"
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
                save_controller.Save_savelist_to_file(save_controller.profile_save_path);
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
                var loaded_game = Load_gamestate();
                return loaded_game;
            case 1:
                GameState? new_game = Create_new_game();
                if(new_game == null)
                {
                    System.Console.WriteLine("Save already exists!");
                    return null;
                }else
                {
                    save_controller.Save_game(new_game);
                    return new_game;
                }
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
    private void Run_game_loop(ref GameState game)
    {
        if (game.generation_count==0) Setup_playing_field(ref game);

        //TODO implement configurable tickrate

        while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
        {   
            Console.Clear();
            Renderer.Renderer.Display_game(ref game, "Press escape to exit");
            StateController.Update_game_state(ref game);
            System.Threading.Thread.Sleep(200);
        }
        if(!save_controller.Save_game(game))
        {
            System.Console.WriteLine("Failed to save game :( Press any key to return to main menu");
            Console.ReadKey(true);
        }
    }

    private void Setup_playing_field(ref GameState game)
    {
        var setup_menu = new FieldSetupMenu(game.current_grid,
        $"Use arrow keys to select a cell. Click enter to toggle its state. Escape to finish setup.{Environment.NewLine}X:Dead O:Alive");
        //TODO setup playing field
        game.current_grid = setup_menu.Run();
        game.current_live_cells = game.current_grid.Count_living_cells();
        StateController.Update_game_state(ref game);
        Run_game_loop(ref game);
    }
    private GameState? Load_gamestate()
    {
        Console.Clear();
        string[]? savenames = save_controller.Return_savenames_as_array();
        if(savenames==null)
        {
            System.Console.WriteLine("No saves found! Press any key to return to main menu.");
            Console.ReadKey(true);
            return null;
        } else
        {
            Menu load_menu = new(savenames, "Choose your save");
            int save_id = load_menu.Run();
            var game = save_controller.Return_game_state_by_index(save_id);
            if(game!=null) 
            {
                return game;
            }
            else 
            {
                System.Console.WriteLine("Failed to load game. Press any key to return to main menu");
                Console.ReadKey(true);
                return null;
            }
        }
    }
    /// <summary>
    /// Generates and displays the scoreboard
    /// </summary>
    private void View_scoreboard()
    {
        Scoreboard scoreboard = new();
        scoreboard.Populate_scoreboard_list(save_controller.save_list);
        if(scoreboard.entry_list.Any())
        {
            scoreboard.Display_scoreboard();
            System.Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey(true);
        } else
        {
            Console.Clear();
            System.Console.WriteLine("The scoreboard is empty");
            System.Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey(true);
        }
    }
    private GameState? Create_new_game()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the player name");
        string playername = Get_string_input();

        //hacky workaround
        if (!Hacks.Get_playernames(save_controller.save_list).Contains(playername))
        {
            return new GameState(playername);
        } else return null;
    }
    private void Run_load_megasave_menu(string[] megasaves)
    {
        string prompt = "Which profile would you like to load?";
        Menu menu = new(megasaves, prompt);
        int cmd_id = menu.Run();
        // Could be done with properties lol.
        string path = megasaves[cmd_id];
        save_controller = new(path, path[path.LastIndexOf(Path.DirectorySeparatorChar)..]);
        // TODO edge case handling?
        if(!save_controller.Load_megasave(save_controller.profile_save_path))
        {
            System.Console.WriteLine("Failed to load profile!");
        }
    }
    private void Create_new_megasave()
    {
        Console.Clear();
        while(true)
        {
            System.Console.WriteLine("Enter profile name");
            string input = Get_string_input();
            string save_path = Path.Combine(save_dir, input)+".golcs";
            if(!File.Exists(save_path)) 
            {
                save_controller = new SaveController(save_path, input);
                break;
            } System.Console.WriteLine("Profile already exists, try again");
            
        }
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
