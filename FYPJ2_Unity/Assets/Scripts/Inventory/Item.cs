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

	void Start()
	{
		itemDisplayName = "DEFAULT";
		itemDisplayDescription = "DEFAULT DESCRIPTOR";
		itemWeight = 0;
	}
}
