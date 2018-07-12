using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public int SceneToTeleportTo;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			SceneChanger.instance.FadeToScene(SceneToTeleportTo);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			SceneChanger.instance.FadeToScene(SceneToTeleportTo);
	}
}
