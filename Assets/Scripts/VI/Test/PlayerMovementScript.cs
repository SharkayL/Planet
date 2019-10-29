using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public enum animalType {
        Dog,
        Turtle,
        Kangaroo
    }

    public animalType type;

    public float moveSpeed;
    
    public float currentSpeed;
    public float rotateSpeed;
   
    public float currentRotateSpeed;
    public float joystickRadius;

    private Vector3 moveDirection;
    private Rigidbody rb;
    [SerializeField]
    private GameObject detectArea;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        detectArea.SetActive(false);
        ActiveRelateScript(true);
    }

    private void OnDisable()
    {
        detectArea.SetActive(true);
        ActiveRelateScript(false);
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
       
   
        if (Mathf.Abs(moveY) > joystickRadius)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);
        }
        if (Mathf.Abs(rotateX) > 0.5f)
        {
            transform.Rotate(0, rotateX * currentRotateSpeed * Time.deltaTime, 0);
        }
        currentSpeed = moveSpeed;
        currentRotateSpeed = rotateSpeed;
        //if (-moveY > joystickRadius || Mathf.Abs(moveX) > joystickRadius)
        //{
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //    rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        //}
        //if (Mathf.Abs(moveX) > joystickRadius) {
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AnimalArea")
        {
            if (ControllerInput.GetButtonY())
            {
                SwitchPlayer(other.GetComponentInParent<PlayerMovementScript>());
            }
        }
    }

    void SwitchPlayer(PlayerMovementScript pms) {
        if (transform.childCount > 1) {
            transform.GetChild(1).parent = pms.transform;
        }
        GetComponent<PlayerMovementScript>().enabled = false;
        pms.enabled = true;
    }

    void ActiveRelateScript(bool b) {
        switch (type) {
            case animalType.Dog:
                GetComponent<Skill_Dog>().enabled = b;
                break;
            case animalType.Kangaroo:
                GetComponent<Skill_Kangaroo>().enabled = b;
                break;
            case animalType.Turtle:
                GetComponent<Turtle>().enabled = b;
                GetComponentInChildren<TriggerDetection>().enabled = b;
                break;
        }
    }
}
