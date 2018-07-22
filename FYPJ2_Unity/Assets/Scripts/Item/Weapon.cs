public class Weapon : Item
{
	public int weaponDamage;

	public void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, int newWeaponDamage)
	{
		displayName = newItemDisplayName;
		displayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		weaponDamage = newWeaponDamage;
	}

	public override string GetStatistics()
	{
		return displayName + "-" + displayDescription + "-" + itemWeight + "-" + weaponDamage;
	}
}
