using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : MonoBehaviour
{
	public string displayName = "DEFAULT_NAME";
	public string displayDescription = "DEFAULT_DESCRIPTOR";


	//Set the strings for the tooltip when the cursor hovers over the button
	public void EnterHover()
	{
		ToolTip.Instance.SetName(displayName);
		ToolTip.Instance.SetDescription(displayDescription);
		ToolTip.Instance.OnHover();
	}

	//Set the strings for the tooltip to empty
	public void ExitHover()
	{
		ToolTip.Instance.ExitHover();
	}
}
