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

	private void Update()
	{
		if(skillObject && skillText)
		{
			skillName = skillObject.GetComponent<SkillBase>().displayName;
			skillText.text = skillName;
		}
	}
}
