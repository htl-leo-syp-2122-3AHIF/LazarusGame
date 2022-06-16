using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem
{
    public static void SaveGame(PlayerStats playerStats, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath+path, FileMode.Create);
        formatter.Serialize(stream, playerStats);
        stream.Close();
        Debug.Log(Application.dataPath + path);
    }
    public static PlayerStats LoadGameData(string path)
    {
        try
        {
           
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Application.dataPath+path, FileMode.Open);
            PlayerStats stats = formatter.Deserialize(stream) as PlayerStats;
            stream.Close();
            return stats;
        }
        catch
        {
            return null;
        }
    }
}
