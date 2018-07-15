using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
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
	[SerializeField]
	protected string skillName = "DEFAULT_NAME";
	[SerializeField]
	protected string skillDescription = "DEFAULT_DESCRIPTOR";

	//Checker function
	protected bool IsUnlockable()
	{
		if (Player.Instance.GetCurrentSkillpoints() < pointsNeeded)
			return false;

		List<SkillBase> playerSkills = Player.Instance.GetSkills();
		foreach(SkillBase skill in skillsNeeded)
		{
			if (!playerSkills.Contains(skill))
				return false;
		}

		return true;
	}

	//Unlocker function
	protected bool UnlockSkill()
	{
		if (IsUnlockable())
		{
			Player.Instance.AddSkill(this);
			isUnlocked = true;

			return isUnlocked;
		}

		return false;
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
	public abstract void ApplySkillEffect();
}
