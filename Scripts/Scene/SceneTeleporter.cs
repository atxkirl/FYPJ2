using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTeleporter : MonoBehaviour
{
	public GameObject player;
	public GameObject teleportPosition;
	public Image fadeImage;
	public bool teleportOnContact = true;
	public bool justTeleported = false;

	void Start()
	{
		Color c = fadeImage.material.color;
		c.a = 0.0f;
		fadeImage.material.color = c;
	}

	void StopMovement()
	{
		if(player != null)
			player.GetComponent<PlayerMovement>().freezePlayer = true;
	}

	void StartTeleport()
	{
		justTeleported = true;
		StopMovement();
		StartCoroutine("ScreenFadeIn");
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			player = other.gameObject;

			if (teleportOnContact && !justTeleported)
			{
				if (teleportPosition.GetComponent<SceneTeleporter>())
				{
					teleportPosition.GetComponent<SceneTeleporter>().justTeleported = true;
				}

				StartTeleport();
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			player = other.gameObject;

			if (!teleportOnContact && !justTeleported)
			{
				if (Input.GetButtonDown("Interact"))
				{
					StartTeleport();
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(player != null)
		{
			player.GetComponent<PlayerMovement>().freezePlayer = false;
			player = null;
			justTeleported = false;
		}
	}

	IEnumerator ScreenFadeIn()
	{
		if(player != null)
		{
			for (float f = 0f; f <= 1f; f += 0.05f)
			{
				Color c = fadeImage.material.color;
				c.a = f;
				fadeImage.material.color = c;

				if (fadeImage.material.color.a >= 0.95f)
				{
					StartCoroutine("ScreenFadeOut");
					player.transform.position = teleportPosition.transform.position;

					yield break;
				}

				yield return new WaitForSeconds(0.05f);
			}
		}
	}

	IEnumerator ScreenFadeOut()
	{
		if (player != null)
		{
			for (float f = 1f; f >= -0.05f; f -= 0.05f)
			{
				Color c = fadeImage.material.color;
				c.a = f;
				fadeImage.material.color = c;

				yield return new WaitForSeconds(0.05f);
			}
		}
	}
}