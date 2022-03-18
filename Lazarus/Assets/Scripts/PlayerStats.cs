using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{

    private const int DEF_MAX_HEALTH = 5;
    private const int DEF_LEVEL = 1;
    private const int DEF_PLAYER_LEVEL = 1;
    private const int DEF_ATTACK_DAMAGE = 5;
    private const string DEF_NAME = "TEST";

    private int _health;
    private int _maxHealth;
    private string _name;
    private float[] _position;
    private int _attackDamage;
    private int _playerLevel;
    private int _level;

    public PlayerStats()
    {
        Health = DEF_MAX_HEALTH;
        MaxHealth = DEF_MAX_HEALTH;
        Name = DEF_NAME;
        AttackDamage = DEF_ATTACK_DAMAGE;
        Level = DEF_LEVEL;
        PlayerLevel = DEF_PLAYER_LEVEL;
        Position = new float[] { 0, 0 };
    }

    public PlayerStats(int health,string name, float[] position, int attackDamage,int playerLevel, int level)
    {
        Health = health;
        Name = name;
        Position = position;
        AttackDamage = attackDamage;
        PlayerLevel = playerLevel;
        Level = level;
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Max(0, value);
        }
    }
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = Mathf.Max(0, value);
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public float[] Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }
    public int AttackDamage
    {
        get
        {
            return _attackDamage;
        }
        set
        {
            _attackDamage = Math.Max(0, value);
        }
    }
    public int PlayerLevel
    {
        get
        {
            return _playerLevel;
        }
        set
        {
            _playerLevel = value;
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }


}
