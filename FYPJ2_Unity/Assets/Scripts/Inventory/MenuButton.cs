using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
	public Text itemText;
	public GameObject itemObject;

	public void SetButton(GameObject buttonObject)
	{
		itemObject = buttonObject;
		itemText.text = buttonObject.GetComponent<Item>().itemDisplayName;
	}

	public void OnClick()
	{

	}
}
