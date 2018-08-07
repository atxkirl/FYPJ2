using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : SingletonMono<PlayerHand>
{
	public GameObject fpsHand;
	public GameObject tpsHand;
	public GameObject childObject;

	[SerializeField]
	private float fpsScale = 0.5f;
	[SerializeField]
	private float tpsScale = 0.25f;

	public void SetObject(GameObject objectToHold)
	{
		Instance.childObject.GetComponent<MeshFilter>().mesh = objectToHold.GetComponent<MeshFilter>().mesh;
		Instance.childObject.GetComponent<MeshRenderer>().materials = objectToHold.GetComponent<MeshRenderer>().materials;
	}

	public void RemoveObject()
	{
		Instance.childObject.GetComponent<MeshFilter>().mesh = null;
	}

	private void Update()
	{
		if(childObject != null && Player.Instance.playerWeapon != null)
		{
			Player.Instance.playerWeapon.transform.parent = childObject.transform;
			Player.Instance.playerWeapon.transform.position = childObject.transform.position;
			Player.Instance.playerWeapon.transform.rotation = childObject.transform.rotation;
		}

		if(CameraManager.Instance.isFPSCamera)
		{
			Instance.childObject.transform.localScale = new Vector3(fpsScale, fpsScale, fpsScale);

			transform.position = fpsHand.transform.position;
			transform.rotation = fpsHand.transform.rotation;
		}
		if (!CameraManager.Instance.isFPSCamera)
		{
			Instance.childObject.transform.localScale = new Vector3(tpsScale, tpsScale, tpsScale);

			transform.position = tpsHand.transform.position;
			transform.rotation = Player.Instance.gameObject.transform.rotation;
		}
	}
}
