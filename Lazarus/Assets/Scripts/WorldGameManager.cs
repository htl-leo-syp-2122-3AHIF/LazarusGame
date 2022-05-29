using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System;
public class WorldGameManager : MonoBehaviour
{
    private VisualElement _menuUI;
    private VisualElement _overWorldUI;
    private PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {

        _playerStats = Const.GetPlayerStatsFromPermanentSave() ;
        SaveLoadSystem.SaveGame(_playerStats, Const.BATTLE_PATH);
        _menuUI = UI.GetAllUIElements("MenuUI");
        _overWorldUI = UI.GetAllUIElements("UI");
        _menuUI.Q<Label>("HealthPointsValue").text=Convert.ToString(_playerStats.Health);
        _menuUI.Q<Label>("AttackDamageValue").text = Convert.ToString(_playerStats.AttackDamage);
        _menuUI.Q<Label>("CritDamageValue").text = Convert.ToString(_playerStats.CritDamage);
        _menuUI.Q<Button>("SaveBtn").clicked += Const.SaveGameData;
        _menuUI.style.display = DisplayStyle.None;

        _overWorldUI.Q<Label>("PlayerName").text = "Name:" +_playerStats.Name;
        _overWorldUI.Q<ProgressBar>("HealthBar").highValue = _playerStats.MaxHealth;
        _overWorldUI.Q<ProgressBar>("HealthBar").value = _playerStats.Health;
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
            _overWorldUI.style.display = DisplayStyle.None;
        }
        else
        {
            _menuUI.style.display = DisplayStyle.None;
            _overWorldUI.style.display = DisplayStyle.Flex;
        }

    }

    
}
