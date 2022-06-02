using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    private const int MAX_HEALTH = 90;
	private const int MIN_HEALTH = 70
	private const int MIN_DAMAGE = 2;
	private const int MAX_DAMAGE = 4;
	private const int CRIT_DAMAGE = 5;
	
	public int health;
	public int damage;
	
	public EnemyStats()
	{
		Random rnd = new Random();
		health = rnd.next(MIN_HEALTH, MAX_HEALTH);
		damage = rnd.next(MIN_DAMAGE, MAX_DAMAGE);
	}
	
	public int Health()
	{
		get
		{
			return health;
		}
	}
	
	public int Damage()
	{
		get
		{
			return damage;
		}
	}
	
	public int Crit_Damage()
	{
		get
		{
			return CRIT_DAMAGE;
		}
	}
}
