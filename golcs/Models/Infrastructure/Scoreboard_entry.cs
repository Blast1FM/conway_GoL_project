using System;
using System.Diagnostics.CodeAnalysis;

namespace golcs.Models.Infrastructure;

public struct Scoreboard_entry : IComparable<Scoreboard_entry>, IEquatable<Scoreboard_entry>
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

    int IComparable<Scoreboard_entry>.CompareTo(Scoreboard_entry other)
    {
        return High_score.CompareTo(other.High_score);
    }

    public bool Equals(Scoreboard_entry other)
    {
        if(this.High_score == other.High_score) return true;
        return false;
    }

    //Haha null go brrrr
    public override bool Equals(object? obj)
    {
        Scoreboard_entry scoreboard_entry_obj = (Scoreboard_entry)obj;
        return Equals(scoreboard_entry_obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
