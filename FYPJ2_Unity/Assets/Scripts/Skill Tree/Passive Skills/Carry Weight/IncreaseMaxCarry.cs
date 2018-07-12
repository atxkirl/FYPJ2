public class IncreaseMaxCarry : SkillBase
{
	public override void ApplySkillEffect()
	{
		Player.Instance.ModifyMaxCarryWeight(skillEffect);
	}
}