using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    Turtle theTurtle;
    private void Start()
    {
        theTurtle = FindObjectOfType<Turtle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            theTurtle.beingGrabed = true;
            theTurtle.theBird = other.gameObject;
        }
    }
}
