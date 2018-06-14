using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
	public bool skillUnlocked;
	public int skillID;
	public int skillCost;
	public int[] skillDependencies;
}
