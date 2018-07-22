using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : SingletonMono<CanvasManager>
{
	public Canvas canvas = null;

	void Update()
	{
		canvas.worldCamera = Camera.main;
	}
}
