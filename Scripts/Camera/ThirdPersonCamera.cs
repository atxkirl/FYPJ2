using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	public Camera playerCamera;
	public Transform TargetLookAt;
	public float distance = 5.0f;
	public float minDistance = 2.0f;
	public float maxDistance = 10.0f;
	public float distanceSmooth = 0.05f;
	public float distanceResumeSmooth = 0.5f;
	public float x_mouseSensitivity = 5.0f;
	public float y_mouseSensitivity = 5.0f;
	public float mouseWheelSensitivity = 5.0f;
	public float x_Smooth = 0.05f;
	public float y_Smooth = 0.1f;
    public float rotate_Smooth_T = 0.1f;
	public float y_MinLimit = -40.0f;
    public float y_MaxLimit = 40.0f;
	public float occlusionDistanceStep = 0.01f;
	public int maxOcclusionChecks = 10;

	public float mouseX = 0f;
	public float mouseY = 0f;
	public float lastMouseX = 0f;
	public float lastMouseY = 0f;

	private float deltaTime = 0f;
	private float checkTime = 0.5f;

	private bool mouseGoingUp = false;
	private bool cameraTooClose = false;

	private float velX = 0f;
	private float velY = 0f;
	private float velZ = 0f;
	private float velDistance = 0f;
    private Vector3 velRotate = Vector3.zero;
	private float startDistance = 0f;
	private Vector3 pos = Vector3.zero;
	private Vector3 desiredPos = Vector3.zero;
	private Vector3 clipPos = Vector3.zero;
	private float desiredDistance = 0f;
	private float preOccludedDistance = 0;

    public void SetMouseXY(Vector2 mouseLook)
    {
        mouseX = mouseLook.x;
        mouseY = -mouseLook.y;
    }

    public Vector2 GetMouseXY()
    {
        return new Vector2(mouseX, -mouseY);
    }

	// Use this for initialization
	void Start()
	{
		distance = Mathf.Clamp(distance, minDistance, maxDistance);
		startDistance = distance;

		Reset();
	}

	void Update()
	{
		deltaTime += Time.deltaTime;
		cameraTooClose = false;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (Cursor.lockState == CursorLockMode.None)
			return;

		if (!TargetLookAt)
			return;

		HandlePlayerInput();

		var count = 0;
		do
		{
			CalculateDesiredPos();
			count++;
		} while (CheckIfOccluded(count));

		UpdatePos();
	}

	void HandlePlayerInput()
	{
		float deadZone = 0.01f;

        if (checkTime <= deltaTime)
        {
            lastMouseX = mouseX;
            lastMouseY = mouseY;
            checkTime = deltaTime + 0.5f;
        }

        // The RMB is down get mouse axis input
        mouseX += Input.GetAxis("Mouse X") * x_mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * y_mouseSensitivity;

        if (lastMouseY < mouseY)
            mouseGoingUp = true;
        else
            mouseGoingUp = false;

        if (!Input.GetMouseButton(1))
        {
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Quaternion rotation = Quaternion.Euler(0, mouseX, 0);

            //if (rotation.eulerAngles.y < -180)
            //{
            //    rotation.eulerAngles.Set(rotation.eulerAngles.x, 180f + rotation.eulerAngles.y, rotation.eulerAngles.z);
            //}
            //else if (rotation.eulerAngles.y > 180)
            //{
            //    rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y - 360, rotation.eulerAngles.z);
            //}

            //player.transform.eulerAngles = Vector3.SmoothDamp(player.transform.eulerAngles, rotation.eulerAngles, ref velRotate, rotate_Smooth);

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, rotate_Smooth_T);
        }

		// This is limiting y
		mouseY = Helper.ClampAngle(mouseY, y_MinLimit, y_MaxLimit);

		if (Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
		{
			desiredDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * mouseWheelSensitivity, minDistance, maxDistance);

			preOccludedDistance = desiredDistance;
		}
	}

	void CalculateDesiredPos()
	{
		// Evaluate Distance
		ResetDesiredDistance();
		distance = Mathf.SmoothDamp(distance, desiredDistance, ref velDistance, distanceSmooth);

		// Calculate desired pos
		desiredPos = CalculatePos(mouseY, mouseX, distance);
	}

	Vector3 CalculatePos(float rotationX, float rotationY, float dist)
	{
		Vector3 direction = new Vector3(0, 0, -dist);
		Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
		return TargetLookAt.position + rotation * direction;
	}

	bool CheckIfOccluded(int count)
	{
		var isOccluded = false;
		var nearestDistance = CheckCameraPoints(TargetLookAt.position, desiredPos);

		if (nearestDistance != -1)
		{
			if (count < maxOcclusionChecks)
			{
				isOccluded = true;
				distance -= occlusionDistanceStep;
			}
			else
				distance = nearestDistance - playerCamera.nearClipPlane;

			if (distance < minDistance)
			{
				distance = minDistance;
				cameraTooClose = true;
			}

			desiredDistance = distance;
		}

		return isOccluded;
	}

	float CheckCameraPoints(Vector3 from, Vector3 to)
	{
		var nearestDistance = -1f;

		RaycastHit hitInfo;

		Helper.ClipPlanePoints clipPlanePoints = Helper.ClipPlaneAtNear(to);

		Debug.DrawLine(from, to + transform.forward * playerCamera.nearClipPlane, Color.red);
		Debug.DrawLine(from, clipPlanePoints.upperLeft);
		Debug.DrawLine(from, clipPlanePoints.lowerLeft);
		Debug.DrawLine(from, clipPlanePoints.upperRight);
		Debug.DrawLine(from, clipPlanePoints.lowerRight);

		Debug.DrawLine(clipPlanePoints.upperLeft, clipPlanePoints.upperRight);
		Debug.DrawLine(clipPlanePoints.upperRight, clipPlanePoints.lowerRight);
		Debug.DrawLine(clipPlanePoints.lowerRight, clipPlanePoints.lowerLeft);
		Debug.DrawLine(clipPlanePoints.lowerLeft, clipPlanePoints.upperLeft);

		if (Physics.Linecast(from, clipPlanePoints.upperLeft, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			nearestDistance = hitInfo.distance;
			clipPos = hitInfo.point;
			clipPos.y = (from + transform.forward * playerCamera.nearClipPlane).y;
		}

		if (Physics.Linecast(from, clipPlanePoints.upperRight, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if (hitInfo.distance < nearestDistance || nearestDistance < 0)
			{
				nearestDistance = hitInfo.distance;
				clipPos = hitInfo.point;
				clipPos.y = (from + transform.forward * playerCamera.nearClipPlane).y;
			}
		}

		if (Physics.Linecast(from, clipPlanePoints.lowerLeft, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if (hitInfo.distance < nearestDistance || nearestDistance < 0)
			{
				nearestDistance = hitInfo.distance;
				clipPos = hitInfo.point;
				clipPos.y = (from + transform.forward * playerCamera.nearClipPlane).y;
			}
		}

		if (Physics.Linecast(from, clipPlanePoints.lowerRight, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if (hitInfo.distance < nearestDistance || nearestDistance < 0)
			{
				nearestDistance = hitInfo.distance;
				clipPos = hitInfo.point;
				clipPos.y = (from + transform.forward * playerCamera.nearClipPlane).y;
			}
		}

		if (Physics.Linecast(from, to + transform.forward * this.GetComponent<Camera>().nearClipPlane, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if (hitInfo.distance < nearestDistance || nearestDistance < 0)
			{
				nearestDistance = hitInfo.distance;
				clipPos = hitInfo.point;
				clipPos.y = (from + transform.forward * playerCamera.nearClipPlane).y;
			}
		}

		return nearestDistance;
	}

	void ResetDesiredDistance()
	{
		if (desiredDistance < preOccludedDistance)
		{
			Vector3 pos;
			if (mouseGoingUp)
			{
				distance += occlusionDistanceStep;
				pos = CalculatePos(mouseY, mouseX, distance);
			}
			else
			{
				pos = CalculatePos(mouseY, mouseX, preOccludedDistance);
			}

			var nearestDistance = CheckCameraPoints(TargetLookAt.position, pos);

			if (nearestDistance < 0 || nearestDistance > preOccludedDistance)
			{
				desiredDistance = preOccludedDistance;
			}
		}
	}

	void UpdatePos()
	{
		float posX = Mathf.SmoothDamp(pos.x, desiredPos.x, ref velX, x_Smooth);
		float posZ = Mathf.SmoothDamp(pos.z, desiredPos.z, ref velZ, x_Smooth);
		float posY;
		if (cameraTooClose && clipPos != Vector3.zero)
		{
			posY = Mathf.SmoothDamp(pos.y, clipPos.y, ref velY, y_Smooth);
		}
		else
		{
			posY = Mathf.SmoothDamp(pos.y, desiredPos.y, ref velY, y_Smooth);
		}

		pos = new Vector3(posX, posY, posZ);
		transform.position = pos;
		transform.LookAt(TargetLookAt);
	}

	public void Reset()
	{
		mouseX = 0;
		mouseY = 10;
		distance = startDistance;
		desiredDistance = distance;
		preOccludedDistance = distance;
	}
}