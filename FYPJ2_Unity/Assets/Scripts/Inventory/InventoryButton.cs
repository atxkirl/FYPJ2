using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
	public Text itemText;
	public GameObject itemObject;

	//Sets the object held in the button
	public void SetButton(GameObject buttonObject)
	{
		itemObject = buttonObject;
		itemText.text = buttonObject.GetComponent<Item>().itemDisplayName;
	}

	//Returns the object held in the button to the controller
	public void OnClick()
	{
		InventoryListControl.instance.ButtonClicked(itemObject);
	}
}
