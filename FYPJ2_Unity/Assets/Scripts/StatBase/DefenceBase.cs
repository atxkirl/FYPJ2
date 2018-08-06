using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceBase : MonoBehaviour
{
	[SerializeField]
	int defence;
	[SerializeField]
	int defenceModifier;

	/// <summary>
	/// Get current defence
	/// </summary>
	public int GetCurrentDefence()
	{
		return defence + defenceModifier;
	}

	/// <summary>
	/// Set current defence
	/// </summary>
	public void SetCurrentDefence(int _defence)
	{
		defence = _defence;
	}

	/// <summary>
	/// Modify current defence
	/// </summary>
	public void ModifyCurrentDefence(int _amountToModify)
	{
		defenceModifier += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref defenceModifier, 0, int.MaxValue - defence);
	}
}
