using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleUIController;
public enum States
{
    Start,
    Player,
    Enemy
}
public class GameManager : MonoBehaviour
{
    
    public Hero player;
    public States currState;
    BattleUI uiController;
    // Start is called before the first frame update
    void Start()
    {
        currState = States.Start;
        uiController = FindObjectOfType<BattleUI>();
        uiController.AttackButton.clicked += Attack;
        uiController.ItemButton.clicked += Items;
        uiController.HealthBar.highValue = player.Health;
        uiController.ChangeHealthBarProgress( player.Health);
        uiController.SetPlayerName("DEMO");
        uiController.SetDialogue("Das ist ein Test");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            case States.Start: break; 
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
