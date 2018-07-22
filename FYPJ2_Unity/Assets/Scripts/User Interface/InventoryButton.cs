using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
	public InventoryListControl controllingInventoryList;
	public Text itemText;
	public GameObject itemObject = null;
	public bool buttonClicked = false;

	private string padding = "  ";

	//Sets the object held in the button
	public void SetButton(GameObject buttonObject)
	{
		itemObject = buttonObject;
		itemText.text = padding + buttonObject.GetComponent<Item>().displayName;
	}

	//Returns the object held in the button to the controller
	public void OnClick()
	{
		controllingInventoryList.ButtonClicked(itemObject);

		//Update button color
		buttonClicked = !buttonClicked;
	}

	public void EnterHover()
	{
		itemObject.GetComponent<Item>().EnterHover();
	}

	public void ExitHover()
	{
		itemObject.GetComponent<Item>().ExitHover();
	}

	private void Update()
	{
		//Button's color
		if(itemObject.GetComponent<Item>().itemEquipped)
			GetComponent<Button>().image.color = Color.green;
		else if (buttonClicked)
			GetComponent<Button>().image.color = Color.gray;
		else
			GetComponent<Button>().image.color = Color.white;
	}
}
