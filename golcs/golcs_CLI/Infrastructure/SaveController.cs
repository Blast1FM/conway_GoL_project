using golcs.World;

namespace golcs.Infrastructure;
public class SaveController
{
    public List<GameState> save_list;

    public SaveController()
    {
        save_list = new List<GameState>();
    }

    //placeholder - need to figure out pathing and serialisation
    public bool Load_megasave(string filepath)
    {
        filepath = filepath.Trim();
        //Handle this, it may fail
        try
        {
            save_list = Serialiser.Deserialise_savelist_from_file(filepath);
            return true;
        }
        catch(Exception)
        {
            return false;
        }
        
    }

    //Returns null if save list doesn't exist, or no 
    public GameState Return_game_state_by_username(string player_name)
    {
        player_name = player_name.Trim();
        if(save_list == null) return null;
        foreach (var gamestate in save_list)
        {
            if (gamestate.player_name == player_name)
            {
                return gamestate;
            }
        }
        return null;
    }

    //Helper method for Save_game. Overwrites existing save with the gamestate passed to it. 
    //If the save list is empty or doesn't contain the save youre looking for, returns false.
    public bool Overwrite_save(GameState game_state)
    {
        string playername = game_state.player_name;
        if (save_list == null) return false;
        for (int i = 0; i < save_list.Count ; i++)
        {
            if(save_list[i].player_name == playername)
            {
                save_list[i] = game_state;
                return true;
            }
        }
        return false;
    }

    //placeholder - Updates the save list if gamestate with its username exists, adds a new entry otherwise
    //true if successful
    //Figure out how it can fail.
    public bool Save_game(GameState game_state)
    {
        if(Overwrite_save(game_state)) return true;
        //Not gonna be null since it's always instantiated in the constructor.
        save_list.Add(game_state);
        return true;
    }

    public bool Save_savelist_to_file(string filename)
    {
        if(save_list == null) return false;
        filename = filename.Trim();
        try
        {
            Serialiser.Serialise_savelist_and_save_to_file(filename, save_list);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
