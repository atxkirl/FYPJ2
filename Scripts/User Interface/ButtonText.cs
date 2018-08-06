using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ButtonText : MonoBehaviour
{
	public string textToDisplay = "DEFAULT_TEXT";
	public Text buttonText;

	private void Update()
	{
		buttonText.fontSize = 20;
		buttonText.text = textToDisplay;
	}
}
