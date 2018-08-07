using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberHelper : SingletonMono<NumberHelper>
{
	public bool CheckBetweenValues(int _amountToCheck, int _min, int _max)
	{
		return ((_amountToCheck < _max) && (_amountToCheck > _min));
	}

	public void ClampBetweenValues(ref int _amountToCheck, int _min, int _max)
	{
		if (_amountToCheck < _min)
			_amountToCheck = _min;
		if (_amountToCheck > _max)
			_amountToCheck = _max;
	}
}
