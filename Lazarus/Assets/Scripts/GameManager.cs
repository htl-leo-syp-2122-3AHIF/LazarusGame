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
    
    public Hero _player;
    public States _currState;
    BattleUI _uiController;
    // Start is called before the first frame update
    void Start()
    {
        _currState = States.Player;
        _uiController = FindObjectOfType<BattleUI>();
        _player = FindObjectOfType<Hero>();
        _uiController.AttackButton.clicked += Attack;
        _uiController.ItemButton.clicked += Items;
        _uiController.HealthBar.highValue = _player.Health;
        _uiController.ChangeHealthBarProgress( _player.Health);
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currState)
        {
            case States.Player:break;
            case States.Enemy:break;

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
