using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
	public float rotateSpeed = 1000;

	private Ray ray;
	private RaycastHit rayCastHit;
	private GameObject itemToRotate;

	void Awake()
	{
		rayCastHit = new RaycastHit();
		itemToRotate = null;
	}

	void Update()
	{
		//Creates a ray projecting from where the cursor is on-screen
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (!Input.GetMouseButton(0))
		{
			itemToRotate = null;

			//Raycasts from cursor position
			if(Physics.Raycast(ray, out rayCastHit))
			{
				if(rayCastHit.collider.gameObject)
				{
					itemToRotate = rayCastHit.collider.gameObject;

					//Checks if item that cursor is over is the itemHolder
					if (itemToRotate != ItemHolder.Instance.gameObject)
						itemToRotate = null;
				}
			}
		}
		else
		{
			//Rotate item about camera's Up and Right axis
			if(itemToRotate)
			{
				rayCastHit.collider.gameObject.transform.RotateAround(rayCastHit.collider.transform.position, Camera.main.transform.up, Time.deltaTime * rotateSpeed * -Input.GetAxis("Mouse X"));
				rayCastHit.collider.gameObject.transform.RotateAround(rayCastHit.collider.transform.position, Camera.main.transform.right, Time.deltaTime * rotateSpeed * Input.GetAxis("Mouse Y"));
			}
		}
	}
}
