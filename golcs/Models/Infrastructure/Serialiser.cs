using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using golcs.Models.World;

#pragma warning disable SYSLIB0011
namespace golcs.Models.Infrastructure;
public class Serialiser
{
    public bool Serialise_savelist_and_save_to_file(string filename, List<GameState> save_list)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        try
        {
            formatter.Serialize(stream, save_list);
            stream.Close();
            return true;
        }
        catch (ArgumentNullException e)
        {       //#TODO find a better way to display the error
                Console.WriteLine(e);
                return false;
        }
    }

    //Maybe return an object instead and let the caller handle it?
    public List<GameState> Deserialise_savelist_from_file(string filepath)
    {
        //Placeholder
        return new List<GameState>();
    }
}
