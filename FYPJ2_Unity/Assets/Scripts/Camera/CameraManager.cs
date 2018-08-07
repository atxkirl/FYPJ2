using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMono<CameraManager>
{
	public Camera fpsCamera;
	public Camera tpsCamera;
	public Camera currCamera;
	public bool isFPSCamera;

	void Start()
	{
		fpsCamera.gameObject.SetActive(true);
		tpsCamera.gameObject.SetActive(false);
		currCamera = Camera.main;
		isFPSCamera = fpsCamera.gameObject.activeSelf;
	}

	void Update()
	{
		if(Input.GetButtonDown("ChangeCameraView"))
		{
			SwapCamera();
		}
	}

	public void SwapCamera()
	{
		fpsCamera.gameObject.SetActive(!fpsCamera.gameObject.activeSelf);
		tpsCamera.gameObject.SetActive(!tpsCamera.gameObject.activeSelf);

        FirstPersonCamera fpsCam = fpsCamera.GetComponent<FirstPersonCamera>();
        ThirdPersonCamera tpsCam = tpsCamera.GetComponent<ThirdPersonCamera>();

		isFPSCamera = fpsCamera.gameObject.activeSelf;

		if (!isFPSCamera)
		{
			tpsCam.SetMouseXY(fpsCam.mouseLook);
		}
		else
		{
			fpsCam.mouseLook = tpsCam.GetMouseXY();
		}

		currCamera = Camera.main;
	}
}
