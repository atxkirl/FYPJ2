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
		if(other.CompareTag("Player") && other.gameObject.GetComponent<Player>())
		{
			player = other.gameObject;

			if (teleportOnContact && !justTeleported)
			{
				if (teleportPosition.GetComponent<SceneTeleporter>())
				{
					teleportPosition.GetComponent<SceneTeleporter>().justTeleported = true;
				}

				//Only start teleport if fadeImage is fully transparent
				if(fadeImage.material.color.a == 0f)
					StartTeleport();
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") && other.gameObject.GetComponent<Player>())
		{
			player = other.gameObject;

			if (!teleportOnContact && !justTeleported)
			{
				if (Input.GetButtonDown("Interact"))
				{
					//Only start teleport if fadeImage is fully transparent
					if (fadeImage.material.color.a == 0f)
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
					player.GetComponent<PlayerMovement>().freezePlayer = true;
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
			Color c;

			for (float f = 1f; f > 0f; f -= 0.05f)
			{
				c = fadeImage.material.color;
				c.a = f;
				fadeImage.material.color = c;

				if (player != null && player.GetComponent<PlayerMovement>())
					player.GetComponent<PlayerMovement>().freezePlayer = true;

				yield return new WaitForSeconds(0.05f);
			}

			c = fadeImage.material.color;
			c.a = 0f;
			fadeImage.material.color = c;
		}
	}
}