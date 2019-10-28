using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public float joystickRadius;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forward = ControllerInput.GetJoystickLeftY();
        if (forward > 0.1f)
        {
            forward = 0;
        }
        moveDirection = new Vector3(0, 0, -forward).normalized;
        //moveDirection = new Vector3(ControllerInput.GetJoystickLeftX(), 0, -ControllerInput.GetJoystickLeftY()).normalized;

    }

    void FixedUpdate()
    {
        float rotateX = ControllerInput.GetJoystickRightX();
        float moveX = ControllerInput.GetJoystickLeftX();
        float moveY = ControllerInput.GetJoystickLeftY();

        //if (-moveY > joystickRadius || Mathf.Abs(moveX) > joystickRadius)
        //{
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //    rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        //}
        if (Mathf.Abs(moveY) > joystickRadius)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        }
        //if (Mathf.Abs(moveX) > joystickRadius) {
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //}
        if (Mathf.Abs(rotateX) > 0.5f)
        {
            transform.Rotate(0, rotateX * rotateSpeed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            ScenesController.JumpScene(1);
        }
    }
}
