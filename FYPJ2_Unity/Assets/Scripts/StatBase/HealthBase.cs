using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
	[SerializeField]
	int health;
	[SerializeField]
	int maxHealth;
	[SerializeField]
	int maxHealthModifier;

	/// <summary>
	/// Get current health
	/// </summary>
	public int GetCurrentHealth()
	{
		return health;
	}

	/// <summary>
	/// Get max health
	/// </summary>
	public int GetMaxHealth()
	{
		return maxHealth + maxHealthModifier;
	}

	/// <summary>
	/// Set current health
	/// </summary>
	public void SetCurrentHealth(int _health)
	{
		health = _health;
	}

	/// <summary>
	/// Set max health
	/// </summary>
	public void SetMaxHealth(int _maxHealth)
	{
		maxHealth = _maxHealth;
	}

	/// <summary>
	/// Modify current health
	/// </summary>
	public void ModifyCurrentHealth(int _amountToModify)
	{
		health += _amountToModify;
		NumberHelper.Instance.ClampBetweenValues(ref health, 0, GetMaxHealth());
	}

	/// <summary>
	/// Modify max health
	/// </summary>
	public void ModifyMaxHealth(int _amountToModify)
	{
		maxHealthModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref maxHealthModifier, -maxHealth, int.MaxValue);
	}

	/// <summary>
	/// Check if health <= 0
	/// </summary>
	public bool CheckIsDead()
	{
		return (health <= 0);
	}
}
