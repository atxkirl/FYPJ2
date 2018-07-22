using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : ButtonBase
{
	[Header("Skill Dependencies")]
	[SerializeField]
	protected bool isUnlocked = false;
	[SerializeField]
	protected int pointsNeeded = 0;
	[SerializeField]
	protected List<SkillBase> skillsNeeded = new List<SkillBase>();

	[Header("Skill Description")]
	[SerializeField]
	protected int skillEffect = 0;

	//Checker function
	protected bool IsUnlockable()
	{
		if (Player.Instance.GetCurrentSkillpoints() < pointsNeeded)
		{
			Debug.Log("Not enought skillpoints. Player has: " + Player.Instance.GetCurrentSkillpoints() + " Skill requires: " + pointsNeeded + ".");
			return false;
		}

		List<SkillBase> playerSkills = Player.Instance.GetSkills();
		foreach(SkillBase skill in skillsNeeded)
		{
			if (!playerSkills.Contains(skill))
			{
				Debug.Log("Player is missing '" + skill.displayName + "' skill.");
				return false;
			}
		}

		Debug.Log(displayName + " is unlockable by player.");
		return true;
	}

	//Unlocker function
	public void UnlockSkill()
	{
		if (IsUnlockable())
		{
			Player.Instance.AddSkill(this);
			isUnlocked = true;
		}
	}

	//Get Skillpoints
	public int GetSkillpointsNeeded()
	{
		return pointsNeeded;
	}

	//Get Skill Effect
	public int GetSkillEffect()
	{
		return skillEffect;
	}

	//Get Skill Unlocked
	public bool GetIsUnlocked()
	{
		return isUnlocked;
	}

	//Get Pre-requisite Skills
	public List<SkillBase> GetRequiredSkills()
	{
		return skillsNeeded;
	}

	//Abstract skill effect function - inherited classes need to implement this
	public virtual void ApplySkillEffect()
	{
		Debug.Log("SkillBase ApplySkillEffect() called. Did you not override this function in child class?");
	}
}
