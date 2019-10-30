using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public enum animalType {
        Dog,
        Turtle,
        Kangaroo
    }

    [Header("Type")]
    public animalType type;

    [Header("MoveMent")]
    public float moveSpeed;
    public float rotateSpeed;
    [Header("DeadZone")]
    public float joystickRadius;
    public float keyboardRadius;
    [HideInInspector]
    public bool canMove;

    private Vector3 moveDirection_Joystick;
    private Vector3 moveDirection_Keyboard;
    private Rigidbody rb;
    [SerializeField]
    private GameObject detectArea;

    PlayerMovementScript switchObj;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        detectArea.SetActive(false);
        canMove = true;
        ActiveRelateScript(true);
    }

    private void OnDisable()
    {
        detectArea.SetActive(true);
        ActiveRelateScript(false);
    }

    void Update()
    {
        JoystickController_Update();
        KeyboardInput_Update();
        if (switchObj != null) {
            if (ControllerInput.GetKeyF() || ControllerInput.GetButtonY()) {
                SwitchPlayer(switchObj);
            }
        }
    }

    void JoystickController_Update() {
        float forward = ControllerInput.GetJoystickLeftY();
        if (forward > 0.1f)
        {
            forward = 0;
        }
        moveDirection_Joystick = new Vector3(0, 0, -forward).normalized;
        //moveDirection = new Vector3(ControllerInput.GetJoystickLeftX(), 0, -ControllerInput.GetJoystickLeftY()).normalized;
    }

    void KeyboardInput_Update() {
        float forward = ControllerInput.GetKeyVertical();
        if (forward < -0.1f)
        {
            forward = 0;
        }
        moveDirection_Keyboard = new Vector3(0, 0, forward).normalized;
    }

    void FixedUpdate()
    {
        if (canMove) {
            JoystickController_FixedUpdate();
            KeyboardInput_FixedUpdate();
        }
    }

    void KeyboardInput_FixedUpdate() {
        float rotateX = ControllerInput.GetKeyHorizontal();
        float moveY = ControllerInput.GetKeyVertical();
        if (Mathf.Abs(moveY) > keyboardRadius)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection_Keyboard) * moveSpeed * Time.deltaTime);
        }
        if (Mathf.Abs(rotateX) > keyboardRadius)
        {
            transform.Rotate(0, rotateX * rotateSpeed * Time.deltaTime, 0);
        }
    }


    void JoystickController_FixedUpdate() {
        float rotateX = ControllerInput.GetJoystickRightX();
        float moveX = ControllerInput.GetJoystickLeftX();
        float moveY = ControllerInput.GetJoystickLeftY();


        if (Mathf.Abs(moveY) > joystickRadius)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection_Joystick) * moveSpeed * Time.deltaTime);
        }
        if (Mathf.Abs(rotateX) > 0.8f)
        {
            transform.Rotate(0, rotateX * rotateSpeed * Time.deltaTime, 0);
        }
        //if (-moveY > joystickRadius || Mathf.Abs(moveX) > joystickRadius)
        //{
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //    rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        //}
        //if (Mathf.Abs(moveX) > joystickRadius) {
        //    transform.Rotate(0, moveX * rotateSpeed * Time.deltaTime, 0);
        //}
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "AnimalArea") {
    //        if (ControllerInput.GetButtonY() || ControllerInput.GetKeyF()) {
    //            SwitchPlayer(other.GetComponentInParent<PlayerMovementScript>());
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AnimalArea") {
            switchObj = other.GetComponentInParent<PlayerMovementScript>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AnimalArea")
        {
            switchObj = null;
        }
    }

    public void SwitchPlayer(PlayerMovementScript pms) {
        transform.GetChild(1).parent = pms.transform;
        if (transform.childCount <= 1) {
            GetComponent<PlayerMovementScript>().enabled = false;
        }
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
