using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Objects/Create Skill")]
public class Skills : ScriptableObject
{
	public string description;
	public Sprite icon;
	public int levelNeeded;
	public int pointsNeeded;

	public List<PlayerAttributes> affectedAttributes = new List<PlayerAttributes>();
}
