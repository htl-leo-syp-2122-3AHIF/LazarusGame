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
    private Inventory _inventory;

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

        _inventory = PlayerStats.Inventory;
        Item item1 = new Item("name", ItemType.Health, 1);
        _inventory.AddItem(item1);
        _inventory.AddItem(item1);

        _inventory.AddItem(item1);
        _inventory.AddItem(item1);

        _inventory.AddItem(item1);
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));
        _inventory.AddItem(new Item("test", ItemType.Attack, 2));

        foreach (Item item in _inventory.Items.Keys)
        {
            Button btn = new Button();
            btn.text =  ""+item.Name+":" + _inventory.Items[item];

            btn.RegisterCallback<ClickEvent>(delegate { 
                _inventory.UseItem(item.Name);
                if(_inventory.Items[item]==0)
                {
                    Debug.Log("Test");
                    _scrollView.Remove(btn);
                    _inventory.Items.Remove(item);
                }
                else
                {
                    btn.text = "" + item.Name + ":" + _inventory.Items[item];
                }
            });
            _scrollView.Add(btn);
        }

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
