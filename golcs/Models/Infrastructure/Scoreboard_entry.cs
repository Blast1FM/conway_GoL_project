using System;

namespace golcs.Models.Infrastructure;

public struct Scoreboard_entry : IComparable<Scoreboard_entry>
{
    public string Playername {get; set;}

    public int Generation_count { get; set;}

    public int High_score {get; set;} 

    public Scoreboard_entry(string arg_playername, int arg_generation_count, int arg_high_score)
    {
        Playername = arg_playername;
        Generation_count = arg_generation_count;
        High_score = arg_high_score;
    }

    readonly int IComparable<Scoreboard_entry>.CompareTo(Scoreboard_entry other)
    {
        return High_score.CompareTo(other.High_score);
    }
}
