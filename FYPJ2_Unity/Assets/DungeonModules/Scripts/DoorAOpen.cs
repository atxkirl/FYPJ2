using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{
	[SerializeField]
	private GameObject doorTeleporter;
	[SerializeField]
	private bool doorOpened;

    // Update is called once per frame
    void Update()
    {
		if(doorTeleporter.GetComponent<SceneTeleporter>().justTeleported && !doorOpened)
		{
			GetComponent<Animator>().SetTrigger("OpenDoor");
			doorOpened = true;
		}
		if (!doorTeleporter.GetComponent<SceneTeleporter>().justTeleported)
		{
			GetComponent<Animator>().ResetTrigger("OpenDoor");
			doorOpened = false;
		}
	}
}