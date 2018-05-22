using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
	//Use this to apply effect upon collision
	void OnTriggerEnter(Collider other)
	{
		//Check if thing colliding is a Player
		if (other.tag == "Player")
		{
			//Add item to player inventory
			InventoryListControl.instance.AddNewItem(this.gameObject);
		}
	}
}
