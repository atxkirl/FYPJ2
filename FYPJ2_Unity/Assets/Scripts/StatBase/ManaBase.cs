using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBase : MonoBehaviour
{
	[SerializeField]
	int mana;
	[SerializeField]
	int maxMana;
	[SerializeField]
	int maxManaModifier;

	/// <summary>
	/// Get current mana
	/// </summary>
	public int GetCurrentMana()
	{
		return mana;
	}

	/// <summary>
	/// Get max mana
	/// </summary>
	public int GetMaxMana()
	{
		return maxMana + maxManaModifier;
	}

	/// <summary>
	/// Set current mana
	/// </summary>
	public void SetCurrentMana(int _mana)
	{
		mana = _mana;
	}

	/// <summary>
	/// Set max mana
	/// </summary>
	public void SetMaxMana(int _maxMana)
	{
		maxMana = _maxMana;
	}

	/// <summary>
	/// Modify current mana
	/// </summary>
	public void ModifyCurrentMana(int _amountToModify)
	{
		mana += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref mana, 0, GetMaxMana());
	}

	/// <summary>
	/// Modify max mana
	/// </summary>
	public void ModifyMaxMana(int _amountToModify)
	{
		maxManaModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref maxManaModifier, -maxMana, int.MaxValue);
	}

	/// <summary>
	/// Check if mana <= 0
	/// </summary>
	public bool CheckIsDead()
	{
		return (mana <= 0);
	}
}
