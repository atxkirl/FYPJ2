using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SkillDisplayText : MonoBehaviour
{
	enum textType
	{
		health,
		stamina,
		mana,
		strength
	}

	[SerializeField]
	string textHeader = "DEFAULT";
	[SerializeField]
	string textToDisplay = "DEFAULT";
	[SerializeField]
	textType displayType = textType.health;

	private void Update()
	{
		if(displayType == textType.health)
			textToDisplay = "+" + Player.Instance.GetComponent<HealthBase>().maxHealthModifier;
		else if (displayType == textType.stamina)
			textToDisplay = "+" + Player.Instance.GetComponent<StaminaBase>().maxStaminaModifier;
		else if(displayType == textType.mana)
			textToDisplay = "+" + Player.Instance.GetComponent<ManaBase>().maxManaModifier;
		else if(displayType == textType.strength)
			textToDisplay = "+" + Player.Instance.GetComponent<CarryWeightBase>().maxCarryWeightModifier;

		GetComponent<Text>().text = textHeader + " = " + textToDisplay;
	}
}
