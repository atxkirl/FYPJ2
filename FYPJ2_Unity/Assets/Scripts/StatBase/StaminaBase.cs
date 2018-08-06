using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBase : MonoBehaviour
{
	[SerializeField]
	int stamina;
	[SerializeField]
	int maxStamina;
	[SerializeField]
	int maxStaminaModifier;

	/// <summary>
	/// Get current stamina
	/// </summary>
	public int GetCurrentStamina()
	{
		return stamina;
	}

	/// <summary>
	/// Get max stamina
	/// </summary>
	public int GetMaxStamina()
	{
		return maxStamina + maxStaminaModifier;
	}

	/// <summary>
	/// Set current stamina
	/// </summary>
	public void SetCurrentStamina(int _stamina)
	{
		stamina = _stamina;
	}

	/// <summary>
	/// Set max stamina
	/// </summary>
	public void SetMaxStamina(int _maxStamina)
	{
		maxStamina = _maxStamina;
	}

	/// <summary>
	/// Modify current stamina
	/// </summary>
	public void ModifyCurrentStamina(int _amountToModify)
	{
		stamina += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref stamina, 0, GetMaxStamina());
	}

	/// <summary>
	/// Modify max stamina
	/// </summary>
	public void ModifyMaxStamina(int _amountToModify)
	{
		maxStaminaModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref maxStaminaModifier, -maxStamina, int.MaxValue);
	}

	/// <summary>
	/// Check if stamina <= 0
	/// </summary>
	public bool CheckIsDead()
	{
		return (stamina <= 0);
	}
}
