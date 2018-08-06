using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for inventory items
/// </summary>

public class Item : MonoBehaviour
{
	public string itemDisplayName = "DEFAULT_NAME";
	public string itemDisplayDescription = "DEFAULT_DESCRIPTOR";
	public int itemWeight = 0;
	public bool itemEquipped = false;
	public GameObject itemModel;

	public virtual void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, GameObject newItemModel)
	{
		itemDisplayName = newItemDisplayName;
		itemDisplayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		itemModel = newItemModel;
	}

	public virtual string GetStatistics()
	{
		return itemDisplayName + "-" + itemDisplayDescription + "-" + itemWeight;
	}
}
