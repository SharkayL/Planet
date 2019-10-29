using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    Turtle theTurtle;
    PlayerMovementScript pms;
    bool isDefening;

    private void Start()
    {
        pms = GetComponentInParent<PlayerMovementScript>();
        theTurtle = FindObjectOfType<Turtle>();
    }

    private void Update()
    {
        if (ControllerInput.GetButtonX_Press())
        {
            pms.currentSpeed = 0;
            pms.currentRotateSpeed = 0;
            isDefening = true;
            Debug.Log("Def");
        }
        else {
            pms.currentSpeed = pms.moveSpeed;
            pms.currentRotateSpeed = pms.rotateSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!isDefening) {
                theTurtle.beingGrabed = true;
                theTurtle.theBird = other.gameObject;
            }
        }
    }
}
