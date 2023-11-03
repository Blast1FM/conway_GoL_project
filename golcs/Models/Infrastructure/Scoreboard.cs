using System.Collections.Generic;
using golcs.Models.World;

namespace golcs.Models.Infrastructure;
public class Scoreboard
{
    public List<Scoreboard_entry> entry_list;

    public void Add_scoreboard_entry(Scoreboard_entry entry)
    {   
        entry_list.Add(entry);
        entry_list.Sort();
    }

    //Shit complexity but i don't give a fuck
    //If I did, i'd just use hash maps :)
    //Or, better yet, call for an update
    //In the particular gamestate that needs an update,
    //And only update that exact entry.
    public void Update_scoreboard(List<GameState> gamestate_list)
    {
        for (int i=0; i< gamestate_list.Count; i++)
        {
            for (int j = 0; j<entry_list.Count; j++)
            {
                if (gamestate_list[i].player_name == entry_list[j].Playername && gamestate_list[i].high_score>entry_list[j].High_score)
                {
                    entry_list[j] = new Scoreboard_entry(gamestate_list[i].player_name, gamestate_list[i].generation_count,gamestate_list[i].high_score);
                }
            }
        }
    }

    public Scoreboard()
    {
        entry_list = new List<Scoreboard_entry>();
    }
}
