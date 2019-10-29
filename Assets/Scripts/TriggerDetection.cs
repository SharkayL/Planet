using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    Turtle theTurtle;
    PlayerMovementScript pms;
    bool isDefening;
    Animator anim;

    private void Start()
    {
        pms = GetComponentInParent<PlayerMovementScript>();
        theTurtle = FindObjectOfType<Turtle>();
        anim = GetComponentInParent<Animator>();

    }
    private void Update()
    {
        anim.SetBool("isHiding", ControllerInput.GetButtonX_Press());

        if (ControllerInput.GetButtonX_Press())
        {
            pms.currentSpeed = 0;
            pms.currentRotateSpeed = 0;
            isDefening = true;
        }
        else {
            pms.currentSpeed = pms.moveSpeed;
            pms.currentRotateSpeed = pms.rotateSpeed;
            isDefening = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (theTurtle) {
                if (!isDefening)
                {
                    theTurtle.beingGrabed = true;
                    theTurtle.theBird = other.gameObject;
                }
            }
           
        }
    }
}
