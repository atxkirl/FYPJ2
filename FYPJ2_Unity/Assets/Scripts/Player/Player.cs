using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : SingletonMono<Player>
{
	//Player Name
	[SerializeField]
	string playerName;

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

	private void Awake()
	{
		///BASE STATS
		//Add component HealthBase
		if (!gameObject.GetComponent<HealthBase>())
			gameObject.AddComponent<HealthBase>();
		//Add component StaminaBase
		if (!gameObject.GetComponent<StaminaBase>())
			gameObject.AddComponent<StaminaBase>();
		//Add component CarryWeightBase
		if (!gameObject.GetComponent<CarryWeightBase>())
			gameObject.AddComponent<CarryWeightBase>();
		//Add component ManaBase
		if (!gameObject.GetComponent<ManaBase>())
			gameObject.AddComponent<ManaBase>();

		///COMBAT STATS
		//Add component AttackBase
		if (!gameObject.GetComponent<AttackBase>())
			gameObject.AddComponent<AttackBase>();
		//Add component DefenceBase
		if (!gameObject.GetComponent<DefenceBase>())
			gameObject.AddComponent<DefenceBase>();
	}

	//////////////////////
	// GETTER FUNCTIONS //
	//////////////////////

	/// <summary>
	/// Get player's current attack damage
	/// </summary>
	public int GetCurrentAttack()
	{
		return gameObject.GetComponent<AttackBase>().GetCurrentAttack();
	}

	/// <summary>
	/// Get player's current defence
	/// </summary>
	public int GetCurrentDefence()
	{
		return gameObject.GetComponent<DefenceBase>().GetCurrentDefence();
	}

	/// <summary>
	/// Get player's current health
	/// </summary>
	public int GetCurrentHealth()
	{
		return gameObject.GetComponent<HealthBase>().GetCurrentHealth();
	}

	/// <summary>
	/// Get player's max health
	/// </summary>
	public int GetMaxHealth()
	{
		return gameObject.GetComponent<HealthBase>().GetMaxHealth();
	}

	/// <summary>
	/// Get player's current stamina
	/// </summary>
	public int GetCurrentStamina()
	{
		return gameObject.GetComponent<StaminaBase>().GetCurrentStamina();
	}

	/// <summary>
	/// Get player's max stamina
	/// </summary>
	public int GetMaxStamina()
	{
		return gameObject.GetComponent<StaminaBase>().GetMaxStamina();
	}

	/// <summary>
	/// Get player's current mana
	/// </summary>
	public int GetCurrentMana()
	{
		return gameObject.GetComponent<ManaBase>().GetCurrentMana();
	}

	/// <summary>
	/// Get player's max mana
	/// </summary>
	public int GetMaxMana()
	{
		return gameObject.GetComponent<ManaBase>().GetMaxMana();
	}

	/// <summary>
	/// Get player's current weight
	/// </summary>
	public int GetCurrentCarryWeight()
	{
		return gameObject.GetComponent<CarryWeightBase>().GetCurrentCarryWeight();
	}

	/// <summary>
	/// Get player's max weight
	/// </summary>
	public int GetMaxCarryWeight()
	{
		return gameObject.GetComponent<CarryWeightBase>().GetMaxCarryWeight();
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
		gameObject.GetComponent<AttackBase>().SetCurrentAttack(_playerAttack);
	}

	/// <summary>
	/// Set player's current defence
	/// </summary>
	public void SetCurrentDefence(int _playerDefence)
	{
		gameObject.GetComponent<DefenceBase>().SetCurrentDefence(_playerDefence);
	}

	/// <summary>
	/// Set player's current health
	/// </summary>
	public void SetCurrentHealth(int _playerHealth)
	{
		gameObject.GetComponent<HealthBase>().SetCurrentHealth(_playerHealth);
	}

	/// <summary>
	/// Set player's max health
	/// </summary>
	public void SetMaxHealth(int _playerMaxHealth)
	{
		gameObject.GetComponent<HealthBase>().SetMaxHealth(_playerMaxHealth);
	}

	/// <summary>
	/// Set player's current stamina
	/// </summary>
	public void SetCurrentStamina(int _playerStamina)
	{
		gameObject.GetComponent<StaminaBase>().SetCurrentStamina(_playerStamina);
	}

	/// <summary>
	/// Set player's max stamina
	/// </summary>
	public void SetMaxStamina(int _playerMaxStamina)
	{
		gameObject.GetComponent<StaminaBase>().SetMaxStamina(_playerMaxStamina);
	}

	/// <summary>
	/// Set player's current mana
	/// </summary>
	public void SetCurrentMana(int _playerMana)
	{
		gameObject.GetComponent<ManaBase>().SetCurrentMana(_playerMana);
	}

	/// <summary>
	/// Set player's max mana
	/// </summary>
	public void SetMaxMana(int _playerMaxMana)
	{
		gameObject.GetComponent<ManaBase>().SetMaxMana(_playerMaxMana);
	}

	/// <summary>
	/// Set player's current weight
	/// </summary>
	public void SetCurrentCarryWeight(int _playerCarryWeight)
	{
		gameObject.GetComponent<CarryWeightBase>().SetCurrentCarryWeight(_playerCarryWeight);
	}

	/// <summary>
	/// Set player's max weight
	/// </summary>
	public void SetMaxCarryWeight(int _playerMaxCarryWeight)
	{
		gameObject.GetComponent<CarryWeightBase>().SetMaxCarryWeight(_playerMaxCarryWeight);
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
		if (playerSkills.Contains(_skill))
		{
			Debug.Log("Player already has skill: " + _skill.displayName);
			return;
		}

		//Instantiate scene-based version of skill
		GameObject skill = (GameObject)Instantiate(Resources.Load("Skills/" + _skill.displayName));
		skill.GetComponent<SkillBase>().SetOwner(gameObject);

		//Set player as skill's owner
		_skill.SetOwner(gameObject);
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
		else if (_item.GetComponent<Weapon>())
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
		gameObject.GetComponent<AttackBase>().ModifyCurrentAttack(_amountToModify);
	}

	/// <summary>
	/// Modify player's current defence
	/// </summary>
	public void ModifyCurrentDefence(int _amountToModify)
	{
		gameObject.GetComponent<DefenceBase>().ModifyCurrentDefence(_amountToModify);
	}

	/// <summary>
	/// Modify player's current health
	/// </summary>
	public void ModifyCurrentHealth(int _amountToModify)
	{
		gameObject.GetComponent<HealthBase>().ModifyCurrentHealth(_amountToModify);
	}

	/// <summary>
	/// Modify player's max health
	/// </summary>
	public void ModifyMaxHealth(int _amountToModify)
	{
		gameObject.GetComponent<HealthBase>().ModifyMaxHealth(_amountToModify);
	}

	/// <summary>
	/// Modify player's current stamina
	/// </summary>
	public void ModifyCurrentStamina(int _amountToModify)
	{
		gameObject.GetComponent<StaminaBase>().ModifyCurrentStamina(_amountToModify);
	}

	/// <summary>
	/// Modify player's max stamina
	/// </summary>
	public void ModifyMaxStamina(int _amountToModify)
	{
		gameObject.GetComponent<StaminaBase>().ModifyMaxStamina(_amountToModify);
	}

	/// <summary>
	/// Modify player's current mana
	/// </summary>
	public void ModifyCurrentMana(int _amountToModify)
	{
		gameObject.GetComponent<ManaBase>().ModifyCurrentMana(_amountToModify);
	}

	/// <summary>
	/// Modify player's max mana
	/// </summary>
	public void ModifyMaxMana(int _amountToModify)
	{
		gameObject.GetComponent<ManaBase>().ModifyMaxMana(_amountToModify);
	}

	/// <summary>
	/// Modify player's current carry weight
	/// </summary>
	public void ModifyCurrentCarryWeight(int _amountToModify)
	{
		gameObject.GetComponent<CarryWeightBase>().ModifyCurrentCarryWeight(_amountToModify);
	}

	/// <summary>
	/// Modify player's max carry weight
	/// </summary>
	public void ModifyMaxCarryWeight(int _amountToModify)
	{
		gameObject.GetComponent<CarryWeightBase>().ModifyMaxCarryWeight(_amountToModify);
	}

	/// <summary>
	/// Modify player's current skillpoints
	/// </summary>
	public void ModifyCurrentSkillpoints(int _amountToModify)
	{
		playerSkillpoints += _amountToModify;

		NumberHelper.Instance.ClampBetweenValues(ref playerSkillpoints, 0, GetMaxSkillpoints());
	}

	///////////////////////
	// CHECKER FUNCTIONS //
	///////////////////////

	/// <summary>
	/// Checks to see if the player is carrying too much stuff
	/// </summary>
	public bool IsOverburdened()
	{
		return gameObject.GetComponent<CarryWeightBase>().CheckIsOverburdened();
	}

	/// <summary>
	/// Checks to see if the player is alive or dead
	/// </summary>
	public bool IsDead()
	{
		return gameObject.GetComponent<HealthBase>().CheckIsDead();
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
}