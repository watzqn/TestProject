using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    //variables
    public float speed = 4f;
    public float sensitivity = 2f;
    public GameObject Eyes;
    float moveFB;
    float moveLR;
    float rotX;
    float rotY;
    float vertVelocity;
    CharacterController player;

	void Start () {
        //gives access to the Player's Character Controller
        player = GetComponent<CharacterController>();

        //Locks and Hides Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	

	void Update () {

        //defining WASD movement
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        //Sprint Script
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8f;
        }
        else
        {
            speed = 4f;
        }

        //assigning moveFB and moveLR to the camera vectors, and vertVelocity for gravity
        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);

        //WASD movement based on the Players rotation
        movement = transform.rotation * movement;

        //applies delta time to the movement of the character controller
        player.Move(movement * Time.deltaTime);

        //defining Mouse movement
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        //Limiting rotY angles
        rotY = Mathf.Clamp(rotY, -70f, 70f);

        //rotX takes over Y rotations
        transform.Rotate(0, rotX, 0);

        //rotY takes over X rotations
        Eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
	}

    void FixedUpdate()
    {
        //applies gravity to the player
        if (player.isGrounded == false)
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            vertVelocity = 0f;
        }
    }
}
