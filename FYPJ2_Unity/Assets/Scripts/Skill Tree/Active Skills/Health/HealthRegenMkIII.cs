using UnityEngine;

public class HealthRegenMkIII : SkillBase
{
	[Header("Active Skill")]
	[SerializeField]
	float elapsedTime = 0.0f;
	[SerializeField]
	float bounceTime = 1.0f;

	private void Update()
	{
		elapsedTime += Time.deltaTime;
	}

	public override void ApplySkillEffect()
	{
		if (elapsedTime > bounceTime)
		{
			elapsedTime -= bounceTime;

			//Add health to the player
			Player.Instance.ModifyCurrentHealth(skillEffect);
		}
	}
}