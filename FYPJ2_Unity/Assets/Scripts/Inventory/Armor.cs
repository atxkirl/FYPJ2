public class Armor : Item
{
	public int armorDefence;

	public void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, int newArmourDefence)
	{
		itemDisplayName = newItemDisplayName;
		itemDisplayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		armorDefence = newArmourDefence;
	}
}
