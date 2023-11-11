using golcs.World;

namespace golcs.Infrastructure;
public class Scoreboard
{
    public List<Scoreboard_entry> entry_list;

    public void Display_scoreboard()
    {
        Console.Clear();
        System.Console.WriteLine("Scoreboard:");
        foreach (var item in entry_list)
        {
            System.Console.WriteLine(item);
        }
    }
    public void Populate_scoreboard_list(List<GameState> gamestate_list)
    {
        foreach (var item in gamestate_list)
        {
            entry_list.Add(new Scoreboard_entry(item.player_name, item.generation_count, item.high_score));
        }
        entry_list.Sort();
        entry_list.Reverse();
    }

    public Scoreboard()
    {
        entry_list = new List<Scoreboard_entry>();
    }
}
