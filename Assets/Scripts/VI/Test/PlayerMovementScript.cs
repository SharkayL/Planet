using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float joystickRadius;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDirection = new Vector3(ControllerInput.GetJoystickLeftX(), 0, -ControllerInput.GetJoystickLeftY()).normalized;
    }

    void FixedUpdate()
    {
        float rotateX = ControllerInput.GetJoystickRightX();
        float moveX = ControllerInput.GetJoystickLeftX();
        float moveY = ControllerInput.GetJoystickLeftY();
        Debug.Log(rotateX);
        if (Mathf.Abs(rotateX)> joystickRadius) {
            transform.Rotate(0, rotateX, 0);
        }
        if (Mathf.Abs(moveX)> joystickRadius || Mathf.Abs(moveY)> joystickRadius)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        }
    }
}
