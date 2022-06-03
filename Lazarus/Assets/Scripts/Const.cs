using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const 
{
    public const string BATTLE_PATH = "/Saves/BattleSave.laz";
    public const string SAVE_PATH = "/Saves/Save.laz";

    public static PlayerStats GetPlayerStatsFromTempSave(bool shouldCreateNew)
    {
        PlayerStats playerStats = SaveLoadSystem.LoadGameData(BATTLE_PATH);
        if(shouldCreateNew&&playerStats==null) return playerStats;
        return playerStats;
    }
    public static PlayerStats GetPlayerStatsFromPermanentSave()
    {
        PlayerStats playerStats = SaveLoadSystem.LoadGameData(SAVE_PATH);
        if (playerStats == null)
        {
            playerStats = new PlayerStats();
        }
        return playerStats;
    }

    public static void SaveGameData()
    {
        SaveLoadSystem.SaveGame(GetPlayerStatsFromTempSave(false),SAVE_PATH);
    }
}
