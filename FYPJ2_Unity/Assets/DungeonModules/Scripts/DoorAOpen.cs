using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{
	[SerializeField]
	private GameObject doorTeleporter;

    // Update is called once per frame
    void Update()
    {
		if(doorTeleporter.GetComponent<SceneTeleporter>().justTeleported)
		{
			GetComponent<Animator>().SetTrigger("OpenDoor");
		}
		if (!doorTeleporter.GetComponent<SceneTeleporter>().justTeleported)
		{
			GetComponent<Animator>().ResetTrigger("OpenDoor");
		}
	}
}