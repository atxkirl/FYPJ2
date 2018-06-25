using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : SingletonMono<Player>
{
	[Header("Player Stats")]
	[SerializeField]
	private string playerName = "DEFAULT_NAME";
	[SerializeField]
	private int playerHealth = 100;
	[SerializeField]
	private int playerStamina = 50;
	[SerializeField]
	private int playerMana = 50;
	[Header("Player Strength")]
	[SerializeField]
	private int playerCurrentCarryWeight = 50;
	private int playerMaxCarryWeight = 100;
	[Header("Player Skillpoints")]
	[SerializeField]
	private int playerSkillPoints = 100;

	//Testing
	[Header("Player Attributes")]
	public List<PlayerAttributes> playerAttributes = new List<PlayerAttributes>();

	[Header("Player Skills Enabled")]
	public List<Skills> playerSkills = new List<Skills>();
	//End of Testing

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

	//Check if the player has a name
	public bool IsNamed()
	{
		return (playerName != "DEFAULT_NAME");
	}

	///////////////////////////////////
	// MODIFY PLAYER STATS FUNCTIONS //
	///////////////////////////////////

	//Modify Health Points
	public void ModifyHealthPoints(int amountToModify)
	{
		playerHealth += amountToModify;

		if (playerHealth < 0)
			playerHealth = 0;
		if (playerHealth > 999)
			playerHealth = 999;
	}

	//Modify Mana Points
	public void ModifyManaPoints(int amountToModify)
	{
		playerMana += amountToModify;

		if (playerMana < 0)
			playerMana = 0;
		if (playerMana > 999)
			playerMana = 999;
	}

	//Modify Stamina Points
	public void ModifyStaminaPoints(int amountToModify)
	{
		playerStamina += amountToModify;

		if (playerStamina < 0)
			playerStamina = 0;
		if (playerStamina > 999)
			playerStamina = 999;
	}

	//Modify Skill Points
	public void ModifySkillPoints(int amountToModify)
	{
		playerSkillPoints += amountToModify;

		if (playerSkillPoints < 0)
			playerSkillPoints = 0;
		if (playerSkillPoints > 999)
			playerSkillPoints = 999;
	}

	//Modify Carry Weight
	public void ModifyCarryWeight(int amountToModify)
	{
		playerCurrentCarryWeight += amountToModify;

		if (playerCurrentCarryWeight < 0)
			playerCurrentCarryWeight = 0;
		if (playerCurrentCarryWeight > 999)
			playerCurrentCarryWeight = 999;
	}

	//Modify Max Carry Weight
	public void ModifyMaxCarryWeight(int amountToModify)
	{
		playerMaxCarryWeight += amountToModify;

		if (playerMaxCarryWeight < 0)
			playerMaxCarryWeight = 0;
		if (playerMaxCarryWeight > 999)
			playerMaxCarryWeight = 999;
	}

	//Modify Player Name
	public void ModifyPlayerName(string name)
	{
		playerName = name;
	}

	///////////////////////////////////
	//  GET PLAYER STATS FUNCTIONS   //
	///////////////////////////////////

	//Get HealthPoints
	public int GetHealthPoints()
	{
		return playerHealth;
	}

	//Get ManaPoints
	public int GetManaPoints()
	{
		return playerMana;
	}

	//Get StaminaPoints
	public int GetStaminaPoints()
	{
		return playerStamina;
	}

	//Get SkillPoints
	public int GetSkillPoints()
	{
		return playerSkillPoints;
	}

	//Get CarryWeight
	public int GetCarryWeight()
	{
		return playerCurrentCarryWeight;
	}

	//Get Max CarryWeight
	public int GetMaxCarryWeight()
	{
		return playerMaxCarryWeight;
	}

	//Get Player Name
	public string GetPlayerName()
	{
		return playerName;
	}
}