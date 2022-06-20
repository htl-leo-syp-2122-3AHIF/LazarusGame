using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MiniGameType
{
    SnakeGame,
    FruitGame,
    BoneZoneGame
}

public class Enemy : MonoBehaviour
{
    public const int MAX_HEALTH = 90;
    public const int MIN_HEALTH = 70;
    public const int MIN_DAMAGE = 2;
    public const int MAX_DAMAGE = 4;
    public const int CRIT_DAMAGE = 5;

    private MiniGameType _miniGameType;
    [SerializeField]
    private List<GameObject> _miniGames;
    [SerializeField]
    private Animator _animator;
    private GameObject _miniGame;
    private BattleManager _battleManager;
    private bool _miniGameActive;
    

    private int _health;
    private int _damage;


    public int Health { get => _health; set => _health = value; }

    public int Damage { get => _damage; }

    public int CritDamage { get => CRIT_DAMAGE; }
    void Start()
    {
        string[] types = Enum.GetNames(typeof(MiniGameType));
        this.transform.tag = types[UnityEngine.Random.Range(0, types.Length)];
        switch(transform.tag)
        {
            case "SnakeGame":_animator.Play("SnakeAnimation"); break;
            case "FruitGame": _animator.Play("ButterflyAnimation"); break;
            case "BoneZoneGame": _animator.Play("SkeletonAnimation"); break;
        }
        _health = UnityEngine.Random.Range(MIN_HEALTH, MAX_HEALTH);
        _damage = UnityEngine.Random.Range(MIN_DAMAGE, MAX_DAMAGE);
        _miniGameActive = false;
        foreach (MiniGameType miniGameType in Enum.GetValues(typeof(MiniGameType)))
        {
            if (miniGameType.ToString() == GameObject.Find("Enemy").tag)
            {
                _miniGameType = miniGameType;
                break;
            }
        }
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
            throw new MissingFieldException("No MiniGames were found");
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
