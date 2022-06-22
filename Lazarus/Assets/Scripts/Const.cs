using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Const 
{
    public const string BATTLE_PATH = "/Saves/BattleSave.laz";
    public const string SAVE_PATH = "/Saves/Save.laz";

    public static PlayerStats GetPlayerStatsFromTempSave(bool shouldCreateNew)
    {
        PlayerStats playerStats = SaveLoadSystem.LoadGameData(BATTLE_PATH);
        if (shouldCreateNew && playerStats == null)
        {
            playerStats = GetPlayerStatsFromPermanentSave();
            if(playerStats== null)
            {
                playerStats = new PlayerStats();
            }
            SaveLoadSystem.SaveGame(playerStats, BATTLE_PATH);
        }
        return playerStats;
    }
    public static PlayerStats GetPlayerStatsFromPermanentSave()
    {
        PlayerStats playerStats = SaveLoadSystem.LoadGameData(SAVE_PATH);

        return playerStats;
    }

    public static void SaveGameData()
    {
        SaveLoadSystem.SaveGame(GetPlayerStatsFromTempSave(false),SAVE_PATH);
    }
    public static void EndGame()
    {
        if (File.Exists(Application.dataPath + BATTLE_PATH))
        {
            File.Delete(Application.dataPath + BATTLE_PATH);
            File.Delete(Application.dataPath + BATTLE_PATH + ".meta");
        }

        Debug.Log("Exit");
        Application.Quit();
    }
    
}
