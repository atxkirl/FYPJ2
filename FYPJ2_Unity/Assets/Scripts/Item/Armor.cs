public class Armor : Item
{
	public enum ArmorType
	{
		ARMR_HELMET,
		ARMR_CHEST,
		ARMR_PANTS,
		ARMR_BOOTS
	}

	public int armorDefence;
	public ArmorType armorType;

	public void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, int newArmourDefence)
	{
		displayName = newItemDisplayName;
		displayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		armorDefence = newArmourDefence;
	}

	public override string GetStatistics()
	{
		return displayName + "-" + displayDescription + "-" + itemWeight + "-" + armorDefence;
	}
}
