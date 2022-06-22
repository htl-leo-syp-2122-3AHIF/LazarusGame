
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem
{
    public static void SaveGame(PlayerStats playerStats, string path)
    {
        if(playerStats!=null)
        {
            using (FileStream stream = new FileStream(Application.dataPath + path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, playerStats);
                Debug.Log(Application.dataPath + path);
            }
        }
        
    }
    public static PlayerStats LoadGameData(string path)
    {
        
        try
        {
            
            using (FileStream stream = new FileStream(Application.dataPath + path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                PlayerStats stats = formatter.Deserialize(stream) as PlayerStats;
                return stats;
            }
                
        }
        catch
        {

            return null;
        }
    }
}
