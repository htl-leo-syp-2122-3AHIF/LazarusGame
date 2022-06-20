using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerStats
{

    private const int DEF_MAX_HEALTH = 15;
    private const int DEF_ATTACK_DAMAGE = 10;
    private const int DEF_CRIT_DAMAGE = 21;
    private const string DEF_NAME = "TEST";

    private float _health;
    private int _maxHealth;
    private string _name;
    private float[] _position;
    private int _attackDamage;
    private int _critDamage;

    public PlayerStats()
    {
        Health = DEF_MAX_HEALTH;
        MaxHealth = DEF_MAX_HEALTH;
        Name = DEF_NAME;
        AttackDamage = DEF_ATTACK_DAMAGE;
        Position = new float[] { 0, 0 };
        _critDamage = DEF_CRIT_DAMAGE;
    }

    public PlayerStats(float health,string name, float[] position, int attackDamage,int critDamage)
    {
        Health = health;
        Name = name;
        Position = position;
        AttackDamage = attackDamage;
        CritDamage = critDamage;
    }

    public PlayerStats(string name)
    {
        _name = name;
        Health = DEF_MAX_HEALTH;
        MaxHealth = DEF_MAX_HEALTH;
        AttackDamage = DEF_ATTACK_DAMAGE;
        Position = new float[] { 0, 0 };
        _critDamage = DEF_CRIT_DAMAGE;
    }

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Math.Max(0, value);
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
            _maxHealth = Math.Max(0, value);
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


    public int CritDamage { get => _critDamage; set => _critDamage = value; }
}
