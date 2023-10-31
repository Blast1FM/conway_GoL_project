using System.Collections.Generic;
using System.IO;
using golcs.Models.World;

namespace golcs.Models.Infrastructure;
public class SaveController
{
    public List<GameState>? save_list;

    //placeholder - need to figure out pathing and serialisation
    public bool Load_megasave()
    {
        return true;
    }

    //placeholder
    public GameState Return_game_state_by_username(string player_name)
    {
        return null;
    }

    //Helper method for Save_game
    public bool Overwrite_save(GameState game_state)
    {
        return true;
    }

    //placeholder - Updates the save list if gamestate with its username exists, adds a new entry otherwise
    //true if successful
    public bool Save_game(GameState game_state)
    {
        return true;
    }
}
