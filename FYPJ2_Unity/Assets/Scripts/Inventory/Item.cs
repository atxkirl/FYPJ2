using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Item>
/// This is a base class for inventory items
/// </Item>

public class Item : MonoBehaviour
{
	public string itemDisplayName;
	public string itemDisplayDescription;
	public int itemWeight;

	void Awake()
	{
		itemDisplayName = "DEFAULT_NAME";
		itemDisplayDescription = "DEFAULT_DESCRIPTOR";
		itemWeight = 0;
	}

	public virtual void SetStatistics(string newItemDisplayName, string newItemDisplayDescription, int newItemWeight)
	{
		itemDisplayName = newItemDisplayName;
		itemDisplayDescription = newItemDisplayDescription;
		itemWeight = newItemWeight;
	}

	public virtual string GetStatistics()
	{
		return itemDisplayName + "-" + itemDisplayDescription + "-" + itemWeight;
	}
}
