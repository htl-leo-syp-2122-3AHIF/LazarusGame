using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleUIController;
public enum States
{
    
    Player,
    Enemy
}
public class GameManager : MonoBehaviour
{
    private const string BATTLE_PATH = "/Saves/BattleSave.laz";


    private States _currState;
    private PlayerStats _playerStats;
    GetBattleUI _uiController;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = SaveLoadSystem.LoadGameData(BATTLE_PATH);
        _uiController = new GetBattleUI();
        _currState = States.Player;
        _uiController.HealthBar.highValue = _playerStats.MaxHealth;
        _uiController.ChangeHealthBarProgress(_playerStats.Health);
        
        _uiController.AttackButton.clicked+=Attack;
        _uiController.ItemButton.clicked += Items;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currState)
        {
            case States.Player:
                _currState = States.Enemy ;
                break;
            case States.Enemy:
                _currState = States.Player;
                break;
        }
    }
    public void Attack()
    {
        Debug.Log("AttackTest");
    }
    public void Items()
    {
        Debug.Log("ItemTest");
    }

}
