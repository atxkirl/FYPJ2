using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryListControl
{
	public override void AddNewItem(GameObject itemToAdd)
	{
		//Check if input is Item
		if (!IsItem(itemToAdd))
			return;

		//Add item to inventory
		base.AddNewItem(itemToAdd);
		//Add item to player
		Player.Instance.AddItem(itemToAdd);
	}

	public override void RemoveItem(GameObject itemToRemove)
	{
		//Check if input is Item
		if (!IsItem(itemToRemove))
			return;

		//Unequip item from player (if it is equipped)
		UnEquipItem(itemToRemove);

		//Remove item from inventory
		base.RemoveItem(itemToRemove);
		//Remove item from player
		Player.Instance.RemoveItem(itemToRemove);
	}

	public void EquipItem(GameObject itemToEquip)
	{
		//Check if input is Item
		if (!IsItem(itemToEquip))
			return;

		//Equip item
		Player.Instance.EquipItem(itemToEquip);
	}

	public void UnEquipItem(GameObject itemToEquip)
	{
		//Check if input is Item
		if (!IsItem(itemToEquip))
			return;

		//UnEquip item
		Player.Instance.UnEquipItem(itemToEquip);
	}
}
