using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
	[SerializeField]
	int attack;
	[SerializeField]
	int attackModifier;

	/// <summary>
	/// Get current attack damage
	/// </summary>
	public int GetCurrentAttack()
	{
		return attack + attackModifier;
	}

	/// <summary>
	/// Set current attack damage
	/// </summary>
	public void SetCurrentAttack(int _attack)
	{
		attack = _attack;
	}

	/// <summary>
	/// Modify current attack damage
	/// </summary>
	public void ModifyCurrentAttack(int _amountToModify)
	{
		attackModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref attackModifier, 0, int.MaxValue - attack);
	}
}
