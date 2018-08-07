using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHand : MonoBehaviour
{
	[SerializeField]
	Camera controllingCamera;
	[SerializeField]
	bool isFPS;

	private void Update()
	{
		if(controllingCamera != null && isFPS)
		{
			gameObject.transform.parent.SetParent(controllingCamera.transform);
			gameObject.transform.rotation = gameObject.transform.parent.rotation;
		}
	}
}
