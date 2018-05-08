﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson_Cam : MonoBehaviour {

    public static ThirdPerson_Cam Instance;

    public Transform TargetLookAt;
    public float distance = 5.0f;
    public float minDistance = 3.0f;
    public float maxDistance = 10.0f;
    public float distanceSmooth = 0.05f;
    public float distanceResumeSmooth = 1f;
    public float x_mouseSensitivity = 5.0f;
    public float y_mouseSensitivity = 5.0f;
    public float mouseWheelSensitivity = 5.0f;
    public float x_Smooth = 0.05f;
    public float y_Smooth = 0.1f;
    public float y_MinLimit = -40.0f;
    public float y_MaxLimit = 40.0f;
    public float occlusionDistanceStep = 0.5f;
    public int maxOcclusionChecks = 10;

    private float mouseX = 0f;
    private float mouseY = 0f;
    private float velX = 0f;
    private float velY = 0f;
    private float velZ = 0f;
    private float velDistance = 0f;
    private float startDistance = 0f;
    private Vector3 pos = Vector3.zero;
    private Vector3 desiredPos = Vector3.zero;
    private float desiredDistance = 0f;
    private float distSmooth = 0f; //Private distanceSmooth to set to distanceSmooth and distanceResumeSmooth
    private float preOccludedDistance = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        startDistance = distance;

        Reset();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
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

        if (Input.GetMouseButton(1))
        {
            // The RMB is down get mouse axis input
            mouseX += Input.GetAxis("Mouse X") * x_mouseSensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * y_mouseSensitivity;
        }

        // This is limiting y
        mouseY = Helper.ClampAngle(mouseY, y_MinLimit, y_MaxLimit);

        if (Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
        {
            desiredDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * mouseWheelSensitivity, minDistance, maxDistance);

            preOccludedDistance = desiredDistance;
            distSmooth = distanceSmooth;
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

                if (distance < 0.25f)
                    distance = 0.25f;
            }
            else
                distance = nearestDistance - Camera.main.nearClipPlane;

            desiredDistance = distance;
            distSmooth = distanceResumeSmooth;
        }
            return isOccluded;
    }

    float CheckCameraPoints(Vector3 from, Vector3 to)
    {
        var nearestDistance = -1f;

        RaycastHit hitInfo;

        Helper.ClipPlanePoints clipPlanePoints = Helper.ClipPlaneAtNear(to);

        Debug.DrawLine(from, to + transform.forward * this.GetComponent<Camera>().nearClipPlane, Color.red);
        Debug.DrawLine(from, clipPlanePoints.upperLeft);
        Debug.DrawLine(from, clipPlanePoints.lowerLeft);
        Debug.DrawLine(from, clipPlanePoints.upperRight);
        Debug.DrawLine(from, clipPlanePoints.lowerRight);

        Debug.DrawLine(clipPlanePoints.upperLeft, clipPlanePoints.upperRight);
        Debug.DrawLine(clipPlanePoints.upperRight, clipPlanePoints.lowerRight);
        Debug.DrawLine(clipPlanePoints.lowerRight, clipPlanePoints.lowerLeft);
        Debug.DrawLine(clipPlanePoints.lowerLeft, clipPlanePoints.upperLeft);

        if (Physics.Linecast(from, clipPlanePoints.upperLeft, out hitInfo) && hitInfo.collider.tag != "Player")
            nearestDistance = hitInfo.distance;

        if (Physics.Linecast(from, clipPlanePoints.lowerLeft, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearestDistance || nearestDistance < 0)
                nearestDistance = hitInfo.distance;
        }

        if (Physics.Linecast(from, clipPlanePoints.upperRight, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearestDistance || nearestDistance < 0)
                nearestDistance = hitInfo.distance;
        }

        if (Physics.Linecast(from, clipPlanePoints.lowerRight, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearestDistance || nearestDistance < 0)
                nearestDistance = hitInfo.distance;
        }

        if (Physics.Linecast(from, to + transform.forward * this.GetComponent<Camera>().nearClipPlane, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearestDistance || nearestDistance < 0)
                nearestDistance = hitInfo.distance;
        }

        return nearestDistance;
    }

    void ResetDesiredDistance()
    {
        if (desiredDistance <  preOccludedDistance)
        {
            var pos = CalculatePos(mouseY, mouseX, preOccludedDistance);

            var nearestDistance = CheckCameraPoints(TargetLookAt.position, pos);

            if (nearestDistance < 0 || nearestDistance > preOccludedDistance)
            {
                desiredDistance = preOccludedDistance;
            }
        }
    }

    void UpdatePos()
    {
        var posX = Mathf.SmoothDamp(pos.x, desiredPos.x, ref velX, x_Smooth);
        var posY = Mathf.SmoothDamp(pos.y, desiredPos.y, ref velY, y_Smooth);
        var posZ = Mathf.SmoothDamp(pos.z, desiredPos.z, ref velZ, x_Smooth);

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

    public static void UseCurrentCamera()
    {
        GameObject tempCamera;
        GameObject targetLookAt;
        ThirdPerson_Cam myCamera;

        if (Camera.main)
        {
            tempCamera = Camera.main.gameObject;
        }
        else
        {
            tempCamera = new GameObject("Main Camera");
            tempCamera.AddComponent<Camera>();
            tempCamera.tag = "MainCamera";
        }

        tempCamera.AddComponent<ThirdPerson_Cam>();
        myCamera = tempCamera.GetComponent<ThirdPerson_Cam>();

        targetLookAt = GameObject.Find("targetLookAt");

        if (!targetLookAt)
        {
            targetLookAt = new GameObject("targetLookAt");
            targetLookAt.transform.position = Vector3.zero;
        }

        myCamera.TargetLookAt = targetLookAt.transform;
    }
}
