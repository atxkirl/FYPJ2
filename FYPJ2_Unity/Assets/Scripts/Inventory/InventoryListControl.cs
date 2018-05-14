using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListControl : MonoBehaviour
{
	public GameObject buttonPrefab;

	void AddNewButton(GameObject itemToAdd)
	{
		GameObject button = Instantiate(buttonPrefab) as GameObject;
		button.SetActive(true);
		
		button.GetComponent<InventoryButton>().SetButton(itemToAdd);
		button.transform.SetParent(buttonPrefab.transform.parent);
		button.transform.localScale = buttonPrefab.transform.localScale;
	}

	void Update()
	{
		//THIS IS TEST CODE
		if(Input.GetKeyDown(KeyCode.E))
		{
			GameObject chestplate = new GameObject("chestplate", typeof(Armor));
			chestplate.GetComponent<Armor>().SetStatistics("chestplate", "test", 10, 10);

			AddNewButton(chestplate);
		}
	}
}
