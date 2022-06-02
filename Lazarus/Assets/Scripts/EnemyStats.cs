using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyStats : MonoBehaviour
{
	private const int MAX_HEALTH = 90;
	private const int MIN_HEALTH = 70;
	private const int MIN_DAMAGE = 2;
	private const int MAX_DAMAGE = 4;
	private const int CRIT_DAMAGE = 5;

	public int _health;
	public int _damage;

	public EnemyStats()
	{
		_health = Random.Range(MIN_HEALTH, MAX_HEALTH);
		_damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE);
	}

	public int Health { get => _health; }

	public int Damage { get => _damage; }

	public int CritDamage { get => CRIT_DAMAGE; }
}
