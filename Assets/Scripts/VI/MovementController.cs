using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Transform planet;
    public Transform player;
    public float moveSpeed;
    public float joystickRadius = 0.75f;

    void Start()
    {
        
    }

    void Update()
    {
        float x, y;
        x = ControllerInput.GetJoystickLeftX() * moveSpeed * Time.deltaTime;
        y = ControllerInput.GetJoystickLeftY() * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(x) > joystickRadius || Mathf.Abs(y) > joystickRadius) {
            planet.Rotate(y,0,-x);
        }
    }
}
