/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem
{
    public static void SaveGame(PlayerStats playerStats, string path)
    {
        File.Create(Application.dataPath + path);
        string lines = "";
        lines += playerStats.Name + "\n";
        lines += playerStats.Health + "\n";
        lines += playerStats.MaxHealth + "\n";
        lines += playerStats.AttackDamage + "\n";
        lines += playerStats.CritDamage + "\n";
        lines += playerStats.Position[0] + ":" + playerStats.Position[1] + "\n";
        File.WriteAllText(Application.dataPath + path, lines); 
    }
    public static PlayerStats LoadGameData(string path)
    {
        try
        {
            string[] lines = File.ReadAllLines(Application.dataPath + path);
            string name = lines[0];
            float health = float.Parse(lines[1]);
            float maxHealth = float.Parse(lines[2]);
            int attackDamage = int.Parse(lines[3]);
            int critDamage = int.Parse(lines[4]);
            string[] pos = lines[5].Split(':');
            float[] position = { float.Parse(pos[0]), float.Parse(pos[1]) };
            return new PlayerStats(health, name, position, attackDamage, critDamage);
        }
        catch
        {
            return null;
        }
        
    }
}*/
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
