using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListControl : MonoBehaviour
{
	public static InventoryListControl instance = null;
	public GameObject canvas;
	public GameObject buttonPrefab;

	public List<GameObject> itemList;
	public List<GameObject> buttonList;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;

		//If instance already exists and it's not this then destroy
		else if (instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		this.gameObject.SetActive(false);

		itemList = new List<GameObject>();
		buttonList = new List<GameObject>();
	}

	//Generates buttons based on items in the itemList
	void GenerateButtons()
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
	void ClearButtons()
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
	void AddNewButton(GameObject itemToAdd)
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
	public void AddNewItem(GameObject itemToAdd)
	{
		itemToAdd.SetActive(false);

		//Add item to list
		itemList.Add(itemToAdd);

		//Regenerate buttons to update
		GenerateButtons();
	}

	//Removes an item from the itemList
	public void RemoveItem()
	{
		//Checks if ItemHolder has a item selected
		if(ItemHolder.instance.itemToPreview)
		{
			//Remove item from itemList and destroy item
			itemList.Remove(ItemHolder.instance.itemToPreview);
			Destroy(ItemHolder.instance.itemToPreview);

			//Regenerate buttons to update
			GenerateButtons();
		}
	}

	//Toggle on/off inventory
	public void ToggleInventory()
	{
		this.gameObject.SetActive(!this.gameObject.activeSelf);

		if (this.gameObject.activeSelf)
		{
			GenerateButtons();
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	//Handles Button Clicks
	public void ButtonClicked(GameObject itemInButton)
	{
		ItemHolder.instance.SetItem(itemInButton);
	}
}
