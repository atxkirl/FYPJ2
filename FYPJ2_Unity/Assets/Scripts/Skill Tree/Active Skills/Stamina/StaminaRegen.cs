using UnityEngine;

public class StaminaRegen : SkillBase
{
	[Header("Active Skill")]
	[SerializeField]
	float elapsedTime = 0.0f;
	[SerializeField]
	float bounceTime = 1.0f;

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		ApplySkillEffect();
	}

	public override void ApplySkillEffect()
	{
		if (elapsedTime > bounceTime)
		{
			elapsedTime -= bounceTime;

			if(skillOwner.GetComponent<StaminaBase>())
			{
				//Add stamina to the player
				skillOwner.GetComponent<StaminaBase>().ModifyCurrentStamina(skillEffect);
			}
		}
	}
}