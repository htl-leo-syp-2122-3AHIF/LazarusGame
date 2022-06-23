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
    [SerializeField]
    private Hero _hero;

    private VisualElement _menuUI;
    private PlayerStats _playerStats;
    private ScrollView _scrollView;
    private Inventory _inventory;
    private Label _healthValue;
    private Label _attackValue;
    private Label _critValue;

    public PlayerStats PlayerStats { get => _playerStats; set => _playerStats = value; }
    public Label HealthValue { get => _healthValue; set => _healthValue = value; }
    public Label AttackValue { get => _attackValue; set => _attackValue = value; }
    public Label CritValue { get => _critValue; set => _critValue = value; }


    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = _hero.PlayerStats;
        
        _menuUI = UI.GetAllUIElements("MenuUI");

        HealthValue = _menuUI.Q<Label>("HealthPointsValue");
        HealthValue.text = Convert.ToString(PlayerStats.Health);
        AttackValue = _menuUI.Q<Label>("AttackDamageValue");
        AttackValue.text = Convert.ToString(PlayerStats.AttackDamage);
        CritValue = _menuUI.Q<Label>("CritDamageValue");
        CritValue.text = Convert.ToString(PlayerStats.CritDamage);
        _menuUI.Q<Button>("SaveBtn").clicked += Const.SaveGameData;
        _menuUI.style.display = DisplayStyle.None;
        _menuUI.Q<Button>("ExitGameBtn").clicked += Const.EndGame;
        _menuUI.Q<Label>("NameValue").text = PlayerStats.Name;
        _scrollView =_menuUI.Q<ScrollView>("items");

        _inventory = PlayerStats.Inventory;
        

        foreach (Item item in _inventory.Items.Keys)
        {
            Button btn = new Button();
            btn.text =  ""+item.Name+":" + _inventory.Items[item];

            btn.RegisterCallback<ClickEvent>(delegate { 
                _inventory.UseItem(item.Name,PlayerStats);
                
                switch (item.Type)
                {
                    case ItemType.Health: HealthValue.text=String.Format("{0}",PlayerStats.Health) ; break;
                    case ItemType.Attack: AttackValue.text = String.Format("{0}", PlayerStats.AttackDamage); break;
                    case ItemType.Crit: CritValue.text = String.Format("{0}", PlayerStats.CritDamage); break;
                }
                if (_inventory.Items[item]==0)
                {
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
