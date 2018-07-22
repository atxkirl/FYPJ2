using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for inventory items
/// </summary>

public class Item : ButtonBase
{
	public int itemWeight = 0;
	public bool itemEquipped = false;
	public GameObject itemModel;

	public virtual void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight, GameObject newItemModel)
	{
		displayName = newItemDisplayName;
		displayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
		itemModel = newItemModel;
	}

	public virtual string GetStatistics()
	{
		return displayName + "-" + displayDescription + "-" + itemWeight;
	}
}
