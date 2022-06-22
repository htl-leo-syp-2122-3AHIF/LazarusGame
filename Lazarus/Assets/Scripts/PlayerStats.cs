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
    private float _maxHealth;
    private string _name;
    private float[] _position;
    private int _attackDamage;
    private int _critDamage;
    private Inventory _inventory;

    public PlayerStats()
    {
        InitiatePlayerStats(DEF_MAX_HEALTH, DEF_NAME, new float[] { 0, 0 }, DEF_ATTACK_DAMAGE, DEF_CRIT_DAMAGE, new Inventory(new Dictionary<Item, int>()));

    }

    public PlayerStats(float health,string name, float[] position, int attackDamage,int critDamage,Inventory inventory)
    {
        InitiatePlayerStats(health, name, position, attackDamage, critDamage, inventory);       
    }

    public PlayerStats(string name)
    {
        InitiatePlayerStats(DEF_MAX_HEALTH, name, new float[] { 0, 0 },DEF_ATTACK_DAMAGE,DEF_CRIT_DAMAGE, new Inventory(new Dictionary<Item, int>()));
    }

    private void InitiatePlayerStats(float health, string name, float[] position, int attackDamage, int critDamage, Inventory inventory)
    {
        Health = health;
        _maxHealth = health ;
        Name = name;
        Position = position;
        AttackDamage = attackDamage;
        CritDamage = critDamage;
        Inventory = inventory;
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
    public float MaxHealth
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


    public Inventory Inventory { get => _inventory; set => _inventory = value; }
}
