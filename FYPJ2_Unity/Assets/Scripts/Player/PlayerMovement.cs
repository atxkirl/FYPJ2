using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SingletonMono<PlayerMovement>
{
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -9.8f;
	public bool freezePlayer = false;

    Vector3 moveDirection;
    CharacterController controller;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (Cursor.lockState == CursorLockMode.None)
			return;

		if (Player.Instance.IsOverburdened())
			speed = 2.0f;
		else if (freezePlayer)
			speed = 0.0f;
		else
			speed = 10.0f;
		
		if (controller.isGrounded)
		{
			moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
			moveDirection *= speed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
        }
		else
		{
			moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical")));
			moveDirection.y -= gravity * Time.deltaTime;
			moveDirection.x *= (speed * 0.5f);
			moveDirection.z *= (speed * 0.5f);
		}
        
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
	}
}
