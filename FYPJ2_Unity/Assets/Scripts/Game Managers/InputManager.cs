using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMono<InputManager>
{
	private void Update()
	{
		//Update inventory
		UpdateInventory();
	}

	private void UpdateInventory()
	{
		if (Input.GetButtonDown("ToggleInventory"))
		{
			GameManager.Instance.playerInventory.ToggleInventory();
		}
		if(Input.GetButtonDown("DeleteItem"))
		{
			if(GameManager.Instance.playerInventory)
				GameManager.Instance.playerInventory.RemoveItem();
		}
	}
}
