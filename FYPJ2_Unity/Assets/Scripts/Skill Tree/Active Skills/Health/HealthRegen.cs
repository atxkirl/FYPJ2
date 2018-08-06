using UnityEngine;

public class HealthRegen : SkillBase
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

			if (skillOwner.GetComponent<HealthBase>())
			{
				//Add health to the player
				skillOwner.GetComponent<HealthBase>().ModifyCurrentHealth(skillEffect);
			}
		}
	}
}
