using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System;
using System.IO;

public class WorldGameManager : MonoBehaviour
{
    private VisualElement _menuUI;
    private PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {

        _playerStats = Const.GetPlayerStatsFromTempSave(true) ;
        if(_playerStats ==null)
        {
            _playerStats = Const.GetPlayerStatsFromPermanentSave() ;
        }
        _menuUI = UI.GetAllUIElements("MenuUI");
        _menuUI.Q<Label>("HealthPointsValue").text=Convert.ToString(_playerStats.Health);
        _menuUI.Q<Label>("AttackDamageValue").text = Convert.ToString(_playerStats.AttackDamage);
        _menuUI.Q<Label>("CritDamageValue").text = Convert.ToString(_playerStats.CritDamage);
        _menuUI.Q<Button>("SaveBtn").clicked += Const.SaveGameData;
        _menuUI.style.display = DisplayStyle.None;
        _menuUI.Q<Button>("ExitGameBtn").clicked += EndGame;
        _menuUI.Q<Label>("NameValue").text = _playerStats.Name;
       
        
    }

    private void EndGame()
    {
        if(File.Exists(Application.dataPath+Const.BATTLE_PATH))
        {
            
            File.Delete(Application.dataPath + Const.BATTLE_PATH);
            File.Delete(Application.dataPath + Const.BATTLE_PATH + ".meta");
        }

        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuInput(InputAction.CallbackContext context)
    {
        if(_menuUI.style.display == DisplayStyle.None)
        {
            _menuUI.style.display = DisplayStyle.Flex;
        }
        else
        {
            _menuUI.style.display = DisplayStyle.None;
        }

    }

    
}
