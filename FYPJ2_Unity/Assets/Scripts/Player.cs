using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : SingletonHelper<Player>
{
	//Player stats
	public string playerName = "DEFAULT_NAME";
	public int playerHealth = 100;
	public int playerStamina = 50;
	public int playerMana = 50;
	//Player leveling
	public int playerLevel = 0;
	public int playerExp = 0;
	//Player carry weight
	public int playerCurrentCarryWeight = 50;
	public int playerMaxCarryWeight = 100;
	//Player skill
	public int playerSkillPoints = 100;

	void Update()
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
			InventoryListControl.Instance.ToggleInventory();
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			GameObject shield = (GameObject)Instantiate(Resources.Load("Items/Armor/Mythril Hulbark"));
			InventoryListControl.Instance.AddNewItem(shield);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			GameObject sword = (GameObject)Instantiate(Resources.Load("Items/Weapon/Sword of Icarus"));
			InventoryListControl.Instance.AddNewItem(sword);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			GameObject item = new GameObject("item", typeof(Item));
			InventoryListControl.Instance.AddNewItem(item);
		}
		if (Input.GetKeyDown(KeyCode.J))
		{
			InventoryListControl.Instance.RemoveItem();
		}
		///End of Test Code
	}

	///////////////////////////////////
	// CHECK PLAYER STATS FUNCTIONS  //
	///////////////////////////////////

	//Check if the player is carrying too much
	public bool IsOverburdened()
	{
		if (playerCurrentCarryWeight > playerMaxCarryWeight)
			return true;
		return false;
	}

	//Check if the player is tired - stamina
	public bool IsTired()
	{
		if (playerStamina <= 0)
			return true;
		return false;
	}

	//Check if the player is drained - mana
	public bool IsDrained()
	{
		if (playerMana <= 0)
			return true;
		return false;
	}

	//Check if the player is dead - health
	public bool IsDead()
	{
		if (playerHealth <= 0)
			return true;
		return false;
	}

	///////////////////////////////////
	// MODIFY PLAYER STATS FUNCTIONS //
	///////////////////////////////////

	//Modify HP
	public void ModifyHP(int amountToModify)
	{
		playerHealth += amountToModify;

		if (playerHealth < 0)
			playerHealth = 0;
	}

	//Modify MP
	public void ModifyMP(int amountToModify)
	{
		playerMana += amountToModify;

		if (playerMana < 0)
			playerMana = 0;
	}

	//Modify SP
	public void ModifySP(int amountToModify)
	{
		playerStamina += amountToModify;

		if (playerStamina < 0)
			playerStamina = 0;
	}

	//Modify CarryWeight
	public void ModifyCarryWeight(int amountToModify)
	{
		playerCurrentCarryWeight += amountToModify;

		if (playerCurrentCarryWeight < 0)
			playerCurrentCarryWeight = 0;
	}
}