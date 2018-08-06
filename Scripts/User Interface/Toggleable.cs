using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour
{
	private void Start()
	{
		this.gameObject.SetActive(false);
	}

	public virtual void Toggle()
	{
		this.gameObject.SetActive(!this.gameObject.activeSelf);

		if (this.gameObject.activeSelf)
		{
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public virtual void Toggle(bool toggleOn)
	{
		this.gameObject.SetActive(toggleOn);
	}
}
