using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : SingletonMono<CanvasManager>
{
	public Canvas mainCanvas = null;

	void Update()
	{
		mainCanvas.worldCamera = Camera.main;
	}
}
