public class IncreaseMaxHealth : SkillBase
{
	public override void ApplySkillEffect()
	{
		Player.Instance.ModifyMaxHealth(skillEffect);
	}
}
