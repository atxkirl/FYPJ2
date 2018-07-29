using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
	public GameObject playerInventory = null;
	public GameObject otherInventory = null;
	public GameObject skillTree = null;

	private void Update()
	{
		//Toggle Inventory
		if (Input.GetButtonDown("ToggleInventory"))
		{
			if (playerInventory)
			{
				playerInventory.GetComponent<InventoryListControl>().Toggle();
				skillTree.GetComponent<Toggleable>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}
		//Toggle SkillTree
		if (Input.GetButtonDown("ToggleSkills"))
		{
			if (skillTree)
			{
				skillTree.GetComponent<Toggleable>().Toggle();
				playerInventory.GetComponent<InventoryListControl>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}

		//Removing Item
		if (Input.GetButtonDown("RemoveItem"))
		{
			if (playerInventory)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					playerInventory.GetComponent<PlayerInventory>().RemoveItem(ItemHolder.Instance.itemToPreview);
				}
			}
		}
		//Equip/UnEquip Item
		if (Input.GetButtonDown("EquipItem") || Input.GetButtonDown("UnEquipItem"))
		{
			if (playerInventory)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					if (ItemHolder.Instance.itemToPreview.GetComponent<Item>().itemEquipped)
					{
						playerInventory.GetComponent<PlayerInventory>().UnEquipItem(ItemHolder.Instance.itemToPreview);
					}
					else if (!ItemHolder.Instance.itemToPreview.GetComponent<Item>().itemEquipped)
					{
						playerInventory.GetComponent<PlayerInventory>().EquipItem(ItemHolder.Instance.itemToPreview);
					}
				}
			}
		}
	}
}
