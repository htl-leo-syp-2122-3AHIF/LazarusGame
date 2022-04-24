using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MiniGameType
{
    SnakeGame
}

public class Enemy : MonoBehaviour
{
    private MiniGameType _miniGameType;
    [SerializeField]
    private List<GameObject> _miniGames;
    private GameObject _miniGame;
    private BattleManager _battleManager;
    private bool _miniGameActive;
    void Start()
    {
        // For testing purposes we use SNAKE
        _miniGameActive = false;
        _miniGameType = MiniGameType.SnakeGame; // Multiple Enemies -> GetArea -> CheckEnemiesInArea -> Randomize which enemy gets selected
        _miniGame = GetMinigame(_miniGameType);
        _battleManager = (BattleManager) GameObject.Find("GameManager").GetComponent("BattleManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (_miniGame != null && _battleManager != null)
        {
            if (_battleManager.CurrState == States.Enemy && !_miniGameActive)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                Instantiate(_miniGame);
                _miniGameActive = true;
            } else if (_battleManager.CurrState == States.Player && _miniGameActive)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                _miniGameActive = false;
            }
        }
    }

    private GameObject GetMinigame(MiniGameType miniGameType)
    {
        if (_miniGames == null)
        {
            Debug.Log("Something went horribly wrong");
            throw new System.MissingFieldException("No MiniGames were found");
        }

        foreach (GameObject game in _miniGames)
        {
            if (game.tag == miniGameType.ToString())
            {
                return game;
            }
        }

        throw new System.MissingFieldException("MiniGame does not exist");
    }
}
