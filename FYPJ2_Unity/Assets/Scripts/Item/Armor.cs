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
		itemDisplayName = newItemDisplayName;
		itemDisplayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		armorDefence = newArmourDefence;
	}

	public override string GetStatistics()
	{
		return itemDisplayName + "-" + itemDisplayDescription + "-" + itemWeight + "-" + armorDefence;
	}
}
