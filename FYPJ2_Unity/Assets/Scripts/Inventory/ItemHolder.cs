﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
	public static ItemHolder instance = null;
	public GameObject itemToPreview;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;

		//If instance already exists and it's not this then destroy
		else if (instance != this)
			Destroy(gameObject);
	}

	void Update()
	{
		if(!itemToPreview)
			this.GetComponent<MeshFilter>().mesh = null;
	}

	public void SetItem(GameObject item)
	{
		itemToPreview = item;
		
		//Set itemHolder's mesh to be the item's mesh, if item does not have a mesh, just set itemHolder's mesh to be null
		if (!item.GetComponent<MeshFilter>())
		{
			this.GetComponent<MeshFilter>().mesh = null;
			return;
		}
		this.GetComponent<MeshFilter>().mesh = itemToPreview.GetComponent<MeshFilter>().mesh;
	}
}
