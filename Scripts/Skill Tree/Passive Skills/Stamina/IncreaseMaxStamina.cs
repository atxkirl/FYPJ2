public class IncreaseMaxStamina : SkillBase
{
	public override void ApplySkillEffect()
	{
		Player.Instance.ModifyMaxStamina(skillEffect);
	}
}