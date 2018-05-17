using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Camera fpsCamera;
	public Camera tpsCamera;
	public bool isFPSCamera;

	void Start()
	{
		fpsCamera.gameObject.SetActive(true);
		tpsCamera.gameObject.SetActive(false);
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

        if (isFPSCamera)
            tpsCam.SetMouseXY(fpsCam.mouseLook);
        else
            fpsCam.mouseLook = tpsCam.GetMouseXY();

        isFPSCamera = fpsCamera.gameObject.activeSelf;

    }
}
