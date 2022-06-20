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
    private ScrollView _scrollView;

    public PlayerStats PlayerStats { get => _playerStats; set => _playerStats = value; }


    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = Const.GetPlayerStatsFromTempSave(true);
        
        _menuUI = UI.GetAllUIElements("MenuUI");
        _menuUI.Q<Label>("HealthPointsValue").text=Convert.ToString(PlayerStats.Health);
        _menuUI.Q<Label>("AttackDamageValue").text = Convert.ToString(PlayerStats.AttackDamage);
        _menuUI.Q<Label>("CritDamageValue").text = Convert.ToString(PlayerStats.CritDamage);
        _menuUI.Q<Button>("SaveBtn").clicked += Const.SaveGameData;
        _menuUI.style.display = DisplayStyle.None;
        _menuUI.Q<Button>("ExitGameBtn").clicked += Const.EndGame;
        _menuUI.Q<Label>("NameValue").text = PlayerStats.Name;
        _scrollView =_menuUI.Q<ScrollView>("items");

        
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
