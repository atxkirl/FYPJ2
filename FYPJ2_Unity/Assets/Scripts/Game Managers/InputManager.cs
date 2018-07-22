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
		//Toggling
		if (Input.GetButtonDown("ToggleInventory"))
		{
			if (playerInventory)
			{
				playerInventory.GetComponent<InventoryListControl>().Toggle();
				skillTree.GetComponent<Toggleable>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}
		if (Input.GetButtonDown("ToggleSkills"))
		{
			if (skillTree)
			{
				skillTree.GetComponent<Toggleable>().Toggle();
				playerInventory.GetComponent<InventoryListControl>().Toggle(false);
				ToolTip.Instance.ExitHover();
			}
		}

		//Inventory control
		if (Input.GetButtonDown("DeleteItem"))
		{
			if (playerInventory)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					playerInventory.GetComponent<PlayerInventory>().RemoveItem(ItemHolder.Instance.itemToPreview);
				}
			}
		}
		if (Input.GetButtonDown("EquipItem"))
		{
			if (playerInventory)
			{
				if (ItemHolder.Instance.itemToPreview)
				{
					playerInventory.GetComponent<PlayerInventory>().EquipItem(ItemHolder.Instance.itemToPreview);
				}
			}
		}
	}
}
