using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : SingletonMono<Player>
{
	//Player Name
	string playerName;

	[Header("Basic Stats")]
	//Health
	[SerializeField]
	int playerHealth;
	[SerializeField]
	int playerMaxHealth;
	[SerializeField]
	int playerMaxHealthModifier;
	//Stamina
	[SerializeField]
	int playerStamina;
	[SerializeField]
	int playerMaxStamina;
	[SerializeField]
	int playerMaxStaminaModifier;
	//Mana
	[SerializeField]
	int playerMana;
	[SerializeField]
	int playerMaxMana;
	[SerializeField]
	int playerMaxManaModifier;
	//Carry Weight
	[SerializeField]
	int playerCarryWeight;
	[SerializeField]
	int playerMaxCarryWeight;
	[SerializeField]
	int playerMaxCarryWeightModifier;

	[Header("Attack/Defence")]
	//Attack
	[SerializeField]
	int playerAttack;
	[SerializeField]
	int playerAttackModifier;
	//Defence
	[SerializeField]
	int playerDefence;
	[SerializeField]
	int playerDefenceModifier;

	[Header("Skills")]
	//Skill
	[SerializeField]
	int playerSkillpoints;
	[SerializeField]
	int playerMaxSkillpoints;
	[SerializeField]
	List<SkillBase> playerSkills = new List<SkillBase>();

	[Header("Inventory")]
	//Inventory
	[SerializeField]
	List<GameObject> playerItems = new List<GameObject>();

	[Header("Equipment")]
	//Equipped Items
	[SerializeField]
	GameObject playerHelmet = null;
	[SerializeField]
	GameObject playerChestplate = null;
	[SerializeField]
	GameObject playerPants = null;
	[SerializeField]
	GameObject playerBoots = null;
	[SerializeField]
	GameObject playerWeapon = null;

	//Max Amounts
	int maxInt = 99999;
	float maxFloat = 99999.0f;

	//////////////////////
	// GETTER FUNCTIONS //
	//////////////////////

	/// <summary>
	/// Get player's current attack damage
	/// </summary>
	public int GetCurrentAttack()
	{
		return playerAttack + playerAttackModifier;
	}

	/// <summary>
	/// Get player's current defence
	/// </summary>
	public int GetCurrentDefence()
	{
		return playerDefence + playerDefenceModifier;
	}

	/// <summary>
	/// Get player's current health
	/// </summary>
	public int GetCurrentHealth()
	{
		return playerHealth;
	}

	/// <summary>
	/// Get player's max health
	/// </summary>
	public int GetMaxHealth()
	{
		return playerMaxHealth + playerMaxHealthModifier;
	}

	/// <summary>
	/// Get player's current stamina
	/// </summary>
	public int GetCurrentStamina()
	{
		return playerStamina;
	}

	/// <summary>
	/// Get player's max stamina
	/// </summary>
	public int GetMaxStamina()
	{
		return playerMaxStamina + playerMaxStaminaModifier;
	}

	/// <summary>
	/// Get player's current mana
	/// </summary>
	public int GetCurrentMana()
	{
		return playerMana;
	}

	/// <summary>
	/// Get player's max mana
	/// </summary>
	public int GetMaxMana()
	{
		return playerMaxMana + playerMaxManaModifier;
	}

	/// <summary>
	/// Get player's current weight
	/// </summary>
	public int GetCurrentCarryWeight()
	{
		return playerCarryWeight;
	}

	/// <summary>
	/// Get player's max weight
	/// </summary>
	public int GetMaxCarryWeight()
	{
		return playerMaxCarryWeight + playerMaxCarryWeightModifier;
	}

	/// <summary>
	/// Get player's current skillpoints
	/// </summary>
	public int GetCurrentSkillpoints()
	{
		return playerSkillpoints;
	}

	/// <summary>
	/// Get player's max skillpoints
	/// </summary>
	public int GetMaxSkillpoints()
	{
		return playerMaxSkillpoints;
	}

	/// <summary>
	/// Get list of player's skills
	/// </summary>
	public List<SkillBase> GetSkills()
	{
		return playerSkills;
	}

	/// <summary>
	/// Get list of player's inventory
	/// </summary>
	public List<GameObject> GetInventory()
	{
		return playerItems;
	}

	//////////////////////
	// SETTER FUNCTIONS //
	//////////////////////

	/// <summary>
	/// Set player's current attack
	/// </summary>
	public void SetCurrentAttack(int _playerAttack)
	{
		playerAttack = _playerAttack;
	}

	/// <summary>
	/// Set player's current defence
	/// </summary>
	public void SetCurrentDefence(int _playerDefence)
	{
		playerDefence = _playerDefence;
	}

	/// <summary>
	/// Set player's current health
	/// </summary>
	public void SetCurrentHealth(int _playerHealth)
	{
		playerHealth = _playerHealth;
	}

	/// <summary>
	/// Set player's max health
	/// </summary>
	public void SetMaxHealth(int _playerMaxHealth)
	{
		playerMaxHealth = _playerMaxHealth;
	}

	/// <summary>
	/// Set player's current stamina
	/// </summary>
	public void SetCurrentStamina(int _playerStamina)
	{
		playerStamina = _playerStamina;
	}

	/// <summary>
	/// Set player's max stamina
	/// </summary>
	public void SetMaxStamina(int _playerMaxStamina)
	{
		playerMaxStamina = _playerMaxStamina;
	}

	/// <summary>
	/// Set player's current mana
	/// </summary>
	public void SetCurrentMana(int _playerMana)
	{
		playerMana = _playerMana;
	}

	/// <summary>
	/// Set player's max mana
	/// </summary>
	public void SetMaxMana(int _playerMaxMana)
	{
		playerMaxMana = _playerMaxMana;
	}

	/// <summary>
	/// Set player's current weight
	/// </summary>
	public void SetCurrentCarryWeight(int _playerCarryWeight)
	{
		playerCarryWeight = _playerCarryWeight;
	}

	/// <summary>
	/// Set player's max weight
	/// </summary>
	public void SetMaxCarryWeight(int _playerMaxCarryWeight)
	{
		playerMaxCarryWeight = _playerMaxCarryWeight;
	}

	/// <summary>
	/// Set player's current skillpoints
	/// </summary>
	public void SetCurrentSkillpoints(int _playerSkillpoints)
	{
		playerSkillpoints = _playerSkillpoints;
	}

	/// <summary>
	/// Set player's max skillpoints
	/// </summary>
	public void SetMaxSkillpoints(int _playerMaxSkillpoints)
	{
		playerMaxSkillpoints = _playerMaxSkillpoints;
	}

	/// <summary>
	/// Set player's list of skills
	/// </summary>
	public void SetSkills(List<SkillBase> _playerSkills)
	{
		playerSkills = _playerSkills;
	}

	//////////////////////////
	// ADD/REMOVE FUNCTIONS //
	//////////////////////////

	/// <summary>
	/// Adds a skill to the player
	/// </summary>
	public void AddSkill(SkillBase _skill)
	{
		//Check if player already has the skill
		if(playerSkills.Contains(_skill))
		{
			return;
		}

		//Add skill to player's list of skill
		playerSkills.Add(_skill);
		//Update player's skillpoints
		ModifyCurrentSkillpoints(-_skill.GetSkillpointsNeeded());
		//Apply new skill's effect to player
		_skill.ApplySkillEffect();
	}

	/// <summary>
	/// Removes a skill from the player
	/// </summary>
	public void RemoveSkill(SkillBase _skill)
	{
		//Check if player has the skill
		if (!playerSkills.Contains(_skill))
		{
			return;
		}

		//Remove skill from player's list of skill
		playerSkills.Remove(_skill);
	}

	/// <summary>
	/// Adds an item to the player
	/// </summary>
	public void AddItem(GameObject _item)
	{
		//Check if input is an Item
		if (!IsItem(_item))
			return;

		//Add item to player's list of items
		playerItems.Add(_item);
		//Update player's carry capacity
		ModifyCurrentCarryWeight(_item.GetComponent<Item>().itemWeight);
	}

	/// <summary>
	/// Removes an item from the player
	/// </summary>
	public void RemoveItem(GameObject _item)
	{
		//Check if input is an Item
		if (!IsItem(_item))
			return;
		//Check if player has this item
		if (!HasItem(_item))
			return;

		//Remove item from player's list of items
		playerItems.Remove(_item);
		//Update player's carry capacity
		ModifyCurrentCarryWeight(-_item.GetComponent<Item>().itemWeight);
	}

	/// <summary>
	/// Equips Items to the player
	/// </summary>
	public void EquipItem(GameObject _item)
	{
		//Check if player has this item
		if (!HasItem(_item))
			return;

		//Item is armour piece
		if (_item.GetComponent<Armor>())
		{
			//Set item into the correct slot
			if(_item.GetComponent<Armor>().armorType.Equals(Armor.ArmorType.ARMR_HELMET))
			{
				if(playerHelmet != null)
				{
					//If the item we're trying to equip has already been equipped, then just return;
					if (playerHelmet.Equals(_item))
						return;
				}
				//If the item is different, then unequip the old armor
				UnEquipItem(playerHelmet);
				//Equip new armor
				playerHelmet = _item;
			}
			else if (_item.GetComponent<Armor>().armorType.Equals(Armor.ArmorType.ARMR_CHEST))
			{
				if(playerChestplate != null)
				{
					//If the item we're trying to equip has already been equipped, then just return;
					if (playerChestplate.Equals(_item))
						return;
				}
				//If the item is different, then unequip the old armor
				UnEquipItem(playerChestplate);
				//Equip new armor
				playerChestplate = _item;
			}
			else if(_item.GetComponent<Armor>().armorType.Equals(Armor.ArmorType.ARMR_PANTS))
			{
				if(playerPants != null)
				{
					//If the item we're trying to equip has already been equipped, then just return;
					if (playerPants.Equals(_item))
						return;
				}
				//If the item is different, then unequip the old armor
				UnEquipItem(playerPants);
				//Equip new armor
				playerPants = _item;
			}
			else if(_item.GetComponent<Armor>().armorType.Equals(Armor.ArmorType.ARMR_BOOTS))
			{
				if(playerBoots != null)
				{
					//If the item we're trying to equip has already been equipped, then just return;
					if (playerBoots.Equals(_item))
						return;
				}
				//If the item is different, then unequip the old armor
				UnEquipItem(playerBoots);
				//Equip new armor
				playerBoots = _item;
			}

			//Update player's defence stats
			ModifyCurrentDefence(_item.GetComponent<Armor>().armorDefence);
		}
		//Item is weapon
		if (_item.GetComponent<Weapon>())
		{
			//Check if the player has any items equipped
			if(playerWeapon != null)
			{
				//If the item we're trying to equip has already been equipped, then just return
				if (playerWeapon.Equals(_item))
				{
					Debug.Log("Trying to equip same item as current weapon.");
					return;
				}
			}
			//If the item is different, then unequip the old weapon
			UnEquipItem(playerWeapon);
			//Equip new weapon
			playerWeapon = _item;

			//Update player's attack stats
			ModifyCurrentAttack(_item.GetComponent<Weapon>().weaponDamage);
		}

		//Set item flag to be equipped
		_item.GetComponent<Item>().itemEquipped = true;
	}

	/// <summary>
	/// UnEquips Items to the player
	/// </summary>
	public void UnEquipItem(GameObject _item)
	{
		//Check if player has this item
		if (!HasItem(_item))
		{
			return;
		}

		//Remove item's buff
		if(_item.GetComponent<Armor>())
		{
			ModifyCurrentDefence(-_item.GetComponent<Armor>().armorDefence);
		}
		if (_item.GetComponent<Weapon>())
		{
			ModifyCurrentAttack(-_item.GetComponent<Weapon>().weaponDamage);
		}
		//Remove item from equipment slot
		if (_item.Equals(playerHelmet))
		{
			playerHelmet = null;
		}
		else if (_item.Equals(playerChestplate))
		{
			playerChestplate = null;
		}
		else if (_item.Equals(playerPants))
		{
			playerPants = null;
		}
		else if (_item.Equals(playerBoots))
		{
			playerBoots = null;
		}
		else if (_item.Equals(playerWeapon))
		{
			playerWeapon = null;
		}

		//Set item to be unequiped
		_item.GetComponent<Item>().itemEquipped = false;
	}

	//////////////////////
	// MODIFY FUNCTIONS //
	//////////////////////

	/// <summary>
	/// Modify player's current attack
	/// </summary>
	public void ModifyCurrentAttack(int _amountToModify)
	{
		playerAttackModifier += _amountToModify;

		ClampBetweenValues(ref playerAttackModifier, 0, maxInt);
	}

	/// <summary>
	/// Modify player's current defence
	/// </summary>
	public void ModifyCurrentDefence(int _amountToModify)
	{
		playerDefenceModifier += _amountToModify;

		ClampBetweenValues(ref playerDefenceModifier, 0, maxInt);
	}

	/// <summary>
	/// Modify player's current health
	/// </summary>
	public void ModifyCurrentHealth(int _amountToModify)
	{
		playerHealth += _amountToModify;

		ClampBetweenValues(ref playerHealth, 0, GetMaxHealth());
	}

	/// <summary>
	/// Modify player's max health
	/// </summary>
	public void ModifyMaxHealth(int _amountToModify)
	{
		playerMaxHealthModifier += _amountToModify;

		ClampBetweenValues(ref playerMaxHealthModifier, -playerMaxHealth, maxInt);
	}

	/// <summary>
	/// Modify player's current stamina
	/// </summary>
	public void ModifyCurrentStamina(int _amountToModify)
	{
		playerStamina += _amountToModify;

		ClampBetweenValues(ref playerStamina, 0, GetMaxStamina());
	}

	/// <summary>
	/// Modify player's max stamina
	/// </summary>
	public void ModifyMaxStamina(int _amountToModify)
	{
		playerMaxStaminaModifier += _amountToModify;

		ClampBetweenValues(ref playerMaxStaminaModifier, -playerMaxStamina, maxInt);
	}

	/// <summary>
	/// Modify player's current mana
	/// </summary>
	public void ModifyCurrentMana(int _amountToModify)
	{
		playerMana += _amountToModify;

		ClampBetweenValues(ref playerMana, 0, GetMaxMana());
	}

	/// <summary>
	/// Modify player's max mana
	/// </summary>
	public void ModifyMaxMana(int _amountToModify)
	{
		playerMaxManaModifier += _amountToModify;

		ClampBetweenValues(ref playerMaxManaModifier, -playerMaxMana, maxInt);
	}

	/// <summary>
	/// Modify player's current carry weight
	/// </summary>
	public void ModifyCurrentCarryWeight(int _amountToModify)
	{
		playerCarryWeight += _amountToModify;

		ClampBetweenValues(ref playerCarryWeight, 0, maxInt);
	}

	/// <summary>
	/// Modify player's max carry weight
	/// </summary>
	public void ModifyMaxCarryWeight(int _amountToModify)
	{
		playerMaxCarryWeightModifier += _amountToModify;

		ClampBetweenValues(ref playerMaxCarryWeightModifier, -playerMaxCarryWeight, 999);
	}

	/// <summary>
	/// Modify player's current skillpoints
	/// </summary>
	public void ModifyCurrentSkillpoints(int _amountToModify)
	{
		playerSkillpoints += _amountToModify;

		ClampBetweenValues(ref playerSkillpoints, 0, GetMaxSkillpoints());
	}

	///////////////////////
	// CHECKER FUNCTIONS //
	///////////////////////

	/// <summary>
	/// Checks to see if the player is carrying too much stuff
	/// </summary>
	public bool IsOverburdened()
	{
		return (playerCarryWeight > GetMaxCarryWeight());
	}

	/// <summary>
	/// Checks to see if the player is alive or dead
	/// </summary>
	public bool IsDead()
	{
		return (playerHealth <= 0);
	}

	/// <summary>
	/// Check if the player has this item in inventory
	/// </summary>
	bool HasItem(GameObject _item)
	{
		return playerItems.Contains(_item);
	}

	/// <summary>
	/// Check if this is an item
	/// </summary>
	bool IsItem(GameObject _item)
	{
		return _item.GetComponent<Item>();
	}

	////////////////////////
	// CLAMPING FUNCTIONS //
	////////////////////////

	private bool CheckBetweenValues(int _amountToCheck, int _min, int _max)
	{
		return ((_amountToCheck < _max) && (_amountToCheck > _min));
	}

	private void ClampBetweenValues(ref int _amountToCheck, int _min, int _max)
	{
		if (_amountToCheck < _min)
			_amountToCheck = _min;
		if (_amountToCheck > _max)
			_amountToCheck = _max;
	}
}