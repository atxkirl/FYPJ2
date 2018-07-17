using System.Collections.Generic;
using UnityEngine;

/// Player class
/// - Handles player stats
/// - Handles player items

public class Player : SingletonMono<Player>
{
	//Player Name
	string playerName;

	//Health
	[SerializeField]
	int playerHealth, playerMaxHealth, playerMaxHealthModifier;
	//Stamina
	[SerializeField]
	int playerStamina, playerMaxStamina, playerMaxStaminaModifier;
	//Mana
	[SerializeField]
	int playerMana, playerMaxMana, playerMaxManaModifier;
	//Carry Weight
	[SerializeField]
	int playerCarryWeight, playerMaxCarryWeight, playerMaxCarryWeightModifier;
	//Skill
	[SerializeField]
	int playerSkillpoints, playerMaxSkillpoints;
	[SerializeField]
	List<SkillBase> playerSkills = new List<SkillBase>();

	//////////////////////
	// GETTER FUNCTIONS //
	//////////////////////

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

	//////////////////////
	// SETTER FUNCTIONS //
	//////////////////////

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

	//////////////////////
	// MODIFY FUNCTIONS //
	//////////////////////

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

		ClampBetweenValues(ref playerMaxHealthModifier, -playerMaxHealth, 999);
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

		ClampBetweenValues(ref playerMaxStaminaModifier, -playerMaxStamina, 999);
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

		ClampBetweenValues(ref playerMaxManaModifier, -playerMaxMana, 999);
	}

	/// <summary>
	/// Modify player's current carry weight
	/// </summary>
	public void ModifyCurrentCarryWeight(int _amountToModify)
	{
		playerCarryWeight += _amountToModify;

		ClampBetweenValues(ref playerCarryWeight, 0, GetMaxCarryWeight());
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