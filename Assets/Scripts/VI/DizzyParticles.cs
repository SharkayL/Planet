using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyParticles : MonoBehaviour
{
    public float timer = 1f;
    float currentTimer;

    private void OnEnable()
    {
        GetComponentInParent<PlayerMovementScript>().enabled = false;
    }

    private void Update()
    {

        transform.Rotate(0, 200*Time.deltaTime, 0);
        if (currentTimer < timer)
        {
            currentTimer += Time.deltaTime;
        }
        else {
            currentTimer = 0;
            GetComponentInParent<PlayerMovementScript>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
