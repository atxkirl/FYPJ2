using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public static CameraManager instance;
	public Camera fpsCamera;
	public Camera tpsCamera;
	public Camera currCamera;
	public bool isFPSCamera;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;

		//If instance already exists and it's not this then destroy
		else if (instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		fpsCamera.gameObject.SetActive(true);
		tpsCamera.gameObject.SetActive(false);
		currCamera = Camera.main;
		isFPSCamera = fpsCamera.gameObject.activeSelf;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.V))
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
			tpsCam.SetMouseXY(fpsCam.mouseLook);
		else
			fpsCam.mouseLook = tpsCam.GetMouseXY();

		currCamera = Camera.main;
	}
}
