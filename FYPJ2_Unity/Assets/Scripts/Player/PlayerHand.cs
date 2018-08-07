using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : SingletonMono<PlayerHand>
{
	public GameObject fpsHand;
	public GameObject tpsHand;
	public GameObject childObject;

	private void Update()
	{
		if(childObject != null && Player.Instance.playerWeapon != null)
		{
			Player.Instance.playerWeapon.transform.parent = childObject.transform;
			Player.Instance.playerWeapon.transform.position = childObject.transform.position;
			Player.Instance.playerWeapon.transform.rotation = childObject.transform.rotation;
		}

		if(fpsHand != null)
		{
			transform.position = fpsHand.transform.position;
			transform.rotation = fpsHand.transform.rotation;
		}
		else if (tpsHand != null)
		{
			transform.position = tpsHand.transform.position;
		}
	}
}
