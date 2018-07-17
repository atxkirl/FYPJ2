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
			}
		}
		if (Input.GetButtonDown("ToggleSkills"))
		{
			if (skillTree)
			{
				skillTree.GetComponent<Toggleable>().Toggle();
				playerInventory.GetComponent<InventoryListControl>().Toggle(false);
			}
		}

		//Inventory control
		if (Input.GetButtonDown("DeleteItem"))
		{
			if (playerInventory)
			{
				playerInventory.GetComponent<InventoryListControl>().RemoveItem();
			}
		}
	}
}
