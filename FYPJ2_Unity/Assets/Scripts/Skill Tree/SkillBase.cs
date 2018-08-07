using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : ButtonBase
{
	[Header("Skill Dependencies")]
	[SerializeField]
	protected GameObject skillOwner = null;
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
	public bool IsUnlockable()
	{
		if (Player.Instance.GetCurrentSkillpoints() < pointsNeeded)
		{
			return false;
		}

		List<SkillBase> playerSkills = Player.Instance.GetSkills();
		foreach(SkillBase skill in skillsNeeded)
		{
			if (!playerSkills.Contains(skill))
			{
				return false;
			}
		}
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

	//Set Skill Owner
	public void SetOwner(GameObject _skillOwner)
	{
		skillOwner = _skillOwner;
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

	//Create shallow copy
	public SkillBase ShallowCopy()
	{
		return (SkillBase)this.MemberwiseClone();
	}

	//Faux constructor
	public void ConstructSkillBase(bool _isUnlocked, int _pointsNeeded, List<SkillBase> _skillsNeeded)
	{
		isUnlocked = _isUnlocked;
		pointsNeeded = _pointsNeeded;
		skillsNeeded = _skillsNeeded;
	}

	//Abstract skill effect function - inherited classes need to implement this
	public virtual void ApplySkillEffect()
	{
		Debug.Log("SkillBase ApplySkillEffect() called. Did you not override this function in child class?");
	}
}
