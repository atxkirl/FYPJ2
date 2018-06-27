using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Player/Create Skill")]
public class Skills : ScriptableObject
{
	public string description;
	public Sprite icon;
	public int levelNeeded;
	public int skillPointsNeeded;

	//List of attributes that the skill will affect
	public List<PlayerAttributes> AffectedAttributes = new List<PlayerAttributes>();
}