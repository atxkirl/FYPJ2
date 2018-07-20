using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListControl : Toggleable
{
	public GameObject buttonPrefab;

	public List<GameObject> itemList = new List<GameObject>();
	public List<GameObject> buttonList = new List<GameObject>();

	//Check if given input is an Item
	protected bool IsItem(GameObject itemToCheck)
	{
		return itemToCheck.GetComponent<Item>();
	}

	//Generates buttons based on items in the itemList
	protected void GenerateButtons()
	{
		//Removes existing buttons
		ClearButtons();

		//Creates buttons according to itemList
		if(itemList.Count > 0)
		{
			foreach(GameObject item in itemList)
			{
				AddNewButton(item.gameObject);
			}
		}
	}

	//Clears buttons from inventory prior to generation
	protected void ClearButtons()
	{
		if (buttonList.Count > 0)
		{
			foreach(GameObject button in buttonList)
			{
				Destroy(button);
			}
			buttonList.Clear();
		}
	}

	//Adds a inventory button with an item attached to it
	protected void AddNewButton(GameObject itemToAdd)
	{
		GameObject button = Instantiate(buttonPrefab) as GameObject;
		button.SetActive(true);
		button.GetComponent<InventoryButton>().SetButton(itemToAdd);
		button.transform.SetParent(buttonPrefab.transform.parent);
		button.transform.localScale = buttonPrefab.transform.localScale;
		button.transform.localPosition = buttonPrefab.transform.localPosition;
		button.transform.localRotation = buttonPrefab.transform.localRotation;

		buttonList.Add(button);
	}

	//Adds an item to the itemList
	public virtual void AddNewItem(GameObject itemToAdd)
	{
		if (!IsItem(itemToAdd))
			return;

		//Disable item
		itemToAdd.SetActive(false);

		//Add item to list
		itemList.Add(itemToAdd);

		//Regenerate buttons to update
		GenerateButtons();
	}

	//Removes an item from the itemList
	public virtual void RemoveItem(GameObject itemToRemove)
	{
		if (!IsItem(itemToRemove))
			return;

		//Remove item from itemList and destroy item
		itemList.Remove(ItemHolder.Instance.itemToPreview);
		Destroy(ItemHolder.Instance.itemToPreview);

		//Regenerate buttons to update
		GenerateButtons();
	}

	//Toggle on/off inventory
	public override void Toggle()
	{
		base.Toggle();

		if (this.gameObject.activeSelf)
		{
			GenerateButtons();
		}
		else
		{
			ItemHolder.Instance.itemToPreview = null;
		}
	}

	//Handles Button Clicks
	public void ButtonClicked(GameObject itemInButton)
	{
		ItemHolder.Instance.SetItem(itemInButton);

		foreach(GameObject button in buttonList)
		{
			button.GetComponent<InventoryButton>().buttonClicked = false;
		}
	}

	//Check if inventory is open
	public bool IsInventoryOpen()
	{
		return this.gameObject.activeInHierarchy;
	}
}
