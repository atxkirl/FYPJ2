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
		//Test Carry Weight
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

		//Test Inventory
		if (Input.GetKeyDown(KeyCode.E))
		{
			InventoryListControl.instance.ToggleInventory();
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			GameObject shield = Instantiate(Resources.Load("Mythril Hulbark")) as GameObject;
			InventoryListControl.instance.AddNewItem(shield);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			GameObject sword = (GameObject)Instantiate(Resources.Load("Sword of Icarus"));
			InventoryListControl.instance.AddNewItem(sword);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			GameObject item = new GameObject("item", typeof(Item));
			InventoryListControl.instance.AddNewItem(item);
		}
		///End of Test Code
	}
}