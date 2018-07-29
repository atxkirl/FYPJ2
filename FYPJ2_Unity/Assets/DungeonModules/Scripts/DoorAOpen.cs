using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
		{

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{

		}
	}
}