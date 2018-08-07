using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SkillButton : MonoBehaviour
{
	[SerializeField]
	private string skillName = "DEFAULT";
	[SerializeField]
	private GameObject skillObject = null;
	[SerializeField]
	private Text skillText = null;
	[SerializeField]
	private Image skillLink = null;

	private void Start()
	{
		GetComponent<Button>().image.color = Color.gray;
		if (skillLink != null)
			skillLink.color = Color.gray;
	}

	private void Update()
	{
		if(skillObject && skillText)
		{
			skillName = skillObject.GetComponent<SkillBase>().displayName;
			skillText.text = skillName;
		}

		//Skill is unlocked by player
		foreach (SkillBase skill in Player.Instance.GetComponent<Player>().GetSkills())
		{
			if (skill.displayName == skillObject.GetComponent<SkillBase>().displayName)
			{
				GetComponent<Button>().image.color = Color.green;
				if (skillLink != null)
					skillLink.color = Color.green;

				return;
			}
		}
		//Skill is unlockable
		if (skillObject.GetComponent<SkillBase>().IsUnlockable())
		{
			GetComponent<Button>().image.color = Color.white;
		}
		//Skill is not unlockable
		else
		{
			GetComponent<Button>().image.color = Color.gray;
			if (skillLink != null)
				skillLink.color = Color.gray;
		}
	}
}
