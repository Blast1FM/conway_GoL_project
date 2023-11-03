using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using golcs.Models.World;

#pragma warning disable SYSLIB0011
namespace golcs.Models.Infrastructure;
public static class Serialiser
{
    public static bool Serialise_savelist_and_save_to_file(string filename, List<GameState> save_list)
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
    public static List<GameState> Deserialise_savelist_from_file(string filepath)
    {
        IFormatter formatter = new BinaryFormatter();
        //Unsafe - caller should check if filepath exists
        Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
        //This can and will fail too omegalul
        List<GameState> save_list = (List<GameState>)formatter.Deserialize(stream); 
        return save_list;
    }
}