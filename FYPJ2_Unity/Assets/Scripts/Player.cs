using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : MonoBehaviour
{
	//Player stats
	public string playerName;
	public int playerHealth;
	public int playerStamina;
	public int playerMana;
	//Player leveling
	public int playerLevel;
	public int playerExp;
	//Player carry weight
	public int playerCurrentCarryWeight;
	public int playerMaxCarryWeight;

	//Check if the player is carrying too much
	public bool IsOverburdened()
	{
		if (playerCurrentCarryWeight > playerMaxCarryWeight)
			return true;
		return false;
	}

	private void Update()
	{
		///Test Code
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			++playerCurrentCarryWeight;
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			--playerCurrentCarryWeight;
			if (playerCurrentCarryWeight < 0)
				playerCurrentCarryWeight = 0;
		}
		///End of Test Code
	}
}