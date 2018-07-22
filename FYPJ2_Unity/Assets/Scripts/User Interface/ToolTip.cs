using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : SingletonMono<ToolTip>
{
	[SerializeField]
	string tooltipName = "DEFAULT_NAME";
	[SerializeField]
	string tooltipDescription = "DEFAULT_DESCRIPTOR";
	[SerializeField]
	Text textName = null;
	[SerializeField]
	Text textDescription = null;

	private void Start()
	{
		ExitHover();
	}

	private void Update()
	{
		textName.text = tooltipName;
		textDescription.text = tooltipDescription;

		//Get the mouse position
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasManager.Instance.canvas.transform as RectTransform, Input.mousePosition, CanvasManager.Instance.canvas.worldCamera, out pos);
		//Offsets
		pos.Set(pos.x + (GetComponent<RectTransform>().rect.width * 0.55f), pos.y - (GetComponent<RectTransform>().rect.height * 0.55f));

		//Set the tooltip position
		transform.position = CanvasManager.Instance.canvas.transform.TransformPoint(pos);
	}

	public void SetName(string _tooltipName)
	{
		tooltipName = _tooltipName;
	}

	public void SetDescription(string _tooltipDescription)
	{
		tooltipDescription = _tooltipDescription;
	}

	public void OnHover()
	{
		gameObject.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
		textName.enabled = true;
		textDescription.enabled = true;
	}

	public void ExitHover()
	{
		tooltipName = "";
		tooltipDescription = "";

		gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
	}
}
