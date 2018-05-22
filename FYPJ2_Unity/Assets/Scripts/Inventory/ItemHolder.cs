using System.Collections;
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

	void OnEnable()
	{
		//Reset itemHolder rotation
		this.gameObject.transform.forward = Camera.main.transform.forward;
		//Reset itemHolder mesh
		this.GetComponent<MeshFilter>().mesh = null;
		this.GetComponent<MeshCollider>().sharedMesh = null;
		this.GetComponent<MeshRenderer>().material = null;
	}

	void Update()
	{
		if (!itemToPreview)
		{
			this.GetComponent<MeshFilter>().mesh = null;
			this.GetComponent<MeshCollider>().sharedMesh = null;
			this.GetComponent<MeshRenderer>().material = null;
		}
	}

	public void SetItem(GameObject item)
	{
		itemToPreview = item;
		
		//Set itemHolder's mesh to be the item's mesh, if item does not have a mesh, just set itemHolder's mesh to be null
		if (!item.GetComponent<MeshFilter>())
		{
			this.GetComponent<MeshFilter>().mesh = null;
			this.GetComponent<MeshCollider>().sharedMesh = null;
			this.GetComponent<MeshRenderer>().material = null;
			return;
		}

		this.GetComponent<MeshFilter>().mesh = itemToPreview.GetComponent<MeshFilter>().mesh;
		this.GetComponent<MeshCollider>().sharedMesh = itemToPreview.GetComponent<MeshFilter>().mesh;
		this.GetComponent<MeshRenderer>().material = itemToPreview.GetComponent<MeshRenderer>().material;

		//Reset itemHolder rotation
		this.gameObject.transform.forward = Camera.main.transform.forward;
	}
}
