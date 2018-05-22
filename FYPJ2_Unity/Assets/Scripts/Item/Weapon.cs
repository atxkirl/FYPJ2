public class Weapon : Item
{
	public int weaponDamage;

	public void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, int newWeaponDamage)
	{
		itemDisplayName = newItemDisplayName;
		itemDisplayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		weaponDamage = newWeaponDamage;
	}

	public override string GetStatistics()
	{
		return itemDisplayName + "-" + itemDisplayDescription + "-" + itemWeight + "-" + weaponDamage;
	}
}
