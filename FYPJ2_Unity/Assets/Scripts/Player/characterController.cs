using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -9.8f;

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
		//Adrian test code
		if (Cursor.lockState == CursorLockMode.None)
			return;

		if (Player.Instance.IsOverburdened())
			speed = 2.0f;
		else
			speed = 10.0f;
		//end of test code

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        moveDirection.y += gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

		//float translation = Input.GetAxis("Vertical") * speed;
  //      float strafe = Input.GetAxis("Horizontal") * speed;
  //      translation *= Time.deltaTime;
  //      strafe *= Time.deltaTime;

  //      transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
	}
}
