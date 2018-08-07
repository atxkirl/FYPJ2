using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryWeightBase : MonoBehaviour
{
	[SerializeField]
	int carryWeight;
	[SerializeField]
	int maxCarryWeight;
	[SerializeField]
	public int maxCarryWeightModifier;

	/// <summary>
	/// Get current carryWeight
	/// </summary>
	public int GetCurrentCarryWeight()
	{
		return carryWeight;
	}

	/// <summary>
	/// Get max carryWeight
	/// </summary>
	public int GetMaxCarryWeight()
	{
		return maxCarryWeight + maxCarryWeightModifier;
	}

	/// <summary>
	/// Set current carryWeight
	/// </summary>
	public void SetCurrentCarryWeight(int _carryWeight)
	{
		carryWeight = _carryWeight;
	}

	/// <summary>
	/// Set max carryWeight
	/// </summary>
	public void SetMaxCarryWeight(int _maxCarryWeight)
	{
		maxCarryWeight = _maxCarryWeight;
	}

	/// <summary>
	/// Modify current carryWeight
	/// </summary>
	public void ModifyCurrentCarryWeight(int _amountToModify)
	{
		carryWeight += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref carryWeight, 0, GetMaxCarryWeight());
	}

	/// <summary>
	/// Modify max carryWeight
	/// </summary>
	public void ModifyMaxCarryWeight(int _amountToModify)
	{
		maxCarryWeightModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref maxCarryWeightModifier, -maxCarryWeight, int.MaxValue);
	}

	/// <summary>
	/// Check if carryWeight > maxCarryWeight + maxCarryWeightModifier
	/// </summary>
	public bool CheckIsOverburdened()
	{
		return (carryWeight > GetMaxCarryWeight());
	}
}
