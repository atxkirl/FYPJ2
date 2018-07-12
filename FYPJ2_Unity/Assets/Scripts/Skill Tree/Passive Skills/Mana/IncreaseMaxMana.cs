public class IncreaseMaxMana : SkillBase
{
	public override void ApplySkillEffect()
	{
		Player.Instance.ModifyMaxMana(skillEffect);
	}
}