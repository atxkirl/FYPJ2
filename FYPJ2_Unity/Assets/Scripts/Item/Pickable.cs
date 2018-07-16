using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
	//Use this to apply effect upon collision
	private void OnTriggerEnter(Collider other)
	{
		//Check if object colliding is Player
		if(other.tag.Equals("Player"))
		{
			//Add item to player inventory
			GameManager.Instance.playerInventory.AddNewItem(this.gameObject);
		}
	}
}
