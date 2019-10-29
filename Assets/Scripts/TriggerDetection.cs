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
        anim.SetBool("isHiding", ControllerInput.GetButtonX_Press() || ControllerInput.GetKeySpace_Press());

        if (ControllerInput.GetButtonX_Press() || ControllerInput.GetKeySpace_Press())
        {
            pms.canMove = false;
            isDefening = true;
        }
        else {
            pms.canMove = true;
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
